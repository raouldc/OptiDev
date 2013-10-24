using System;
using System.Linq;
using System.Net;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.IO;
using System.Threading;
using HtmlAgilityPack;
using System.Collections.Generic;

namespace P02Project.Resources.xml
{
    class XMLUtilities
    {
        public static PageModel GetContentFromFile(String filePath)
        {
            var mySerializer = new XmlSerializer(typeof(PageModel));

            PageModel xmlContent;
            using (var myFileStream = new FileStream(filePath, FileMode.Open))
            {
                xmlContent = (PageModel)mySerializer.Deserialize(myFileStream);
            }

            return xmlContent;

        }

        public static BeadModel GetBeadsContentFromFile(String filePath)
        {
            var mySerializer = new XmlSerializer(typeof(BeadModel));

            BeadModel xmlContent;
            using (var myFileStream = new FileStream(filePath, FileMode.Open))
            {
                xmlContent = (BeadModel)mySerializer.Deserialize(myFileStream);
            }

            return xmlContent;

        }

        public static PageModel GetContentFromPage(string url)
        {
            var pageType = url.Split('/').LastOrDefault().Split('.').FirstOrDefault();
            var path = "Resources/xml/" + pageType + ".xml";
            //If the requested file doesn't exist, or if the file is more than 12 hours old, try getting new file
            if (!File.Exists(path)
                || File.GetLastWriteTimeUtc(path) < DateTime.UtcNow.Subtract(new TimeSpan(12, 0, 0)))
            {

                try
                {
                    //keep a list of all running threads
                    var threadList = new List<Thread>();
                    var html = new HtmlWeb();
                    var page = html.Load(url);
                    var itemList =
                        page.GetElementbyId("contentPrimary").Elements("div").Where(
                            node => node.Attributes["class"].Value == "item").ToList();
                    //Create file structure
                    var xml = new XDocument(
                        new XElement("PageModel", new XAttribute("id", pageType),
                                new XElement("TextList"),
                                new XElement("ImageList"),
                                new XElement("LinksList")
                                )
                            );
                    var nNode = 1;
                    foreach (var htmlNode in itemList)
                    {
                        //Add element to text list for each htmlNode, with title, info, date and place
                        var element = xml.Descendants("TextList").FirstOrDefault();
                        element.Add(
                            new XElement("Text", new XAttribute("node", nNode), new XAttribute("type", "title"), htmlNode.Descendants("a").FirstOrDefault().InnerText.Replace("&", "and")));
                        element.Add(
                            new XElement("Text", new XAttribute("node", nNode), new XAttribute("type", "info"), htmlNode.Descendants("p").FirstOrDefault().InnerText.Replace("&", "and")));
                        var content = htmlNode.Descendants("small").FirstOrDefault().InnerText.Replace("&", "and");
                        element.Add(
                            new XElement("Text", new XAttribute("node", nNode), new XAttribute("type", "date"), (pageType == "Events" ? content.Substring(0, content.IndexOf("\r\nWhere: ")) : content)));
                        element.Add(
                            new XElement("Text", new XAttribute("node", nNode), new XAttribute("type", "place"), (pageType == "Events" ? content.Substring(content.IndexOf("Where: ")) : "")));
                        //build path for image
                        var imagePath = "images/" + pageType + "/" + htmlNode.Descendants("a").FirstOrDefault().InnerText.Replace("/", "-").Replace("\\", "-").Replace(" ", "") + ".jpg";
                        imagePath = imagePath.Replace(":", " -");
                        //if the image is not already in cache, create a new thread and download
                        if (!File.Exists("Resources/" + imagePath))
                        {
                            //Check if folder structure is there, if not create folder
                            if (!Directory.Exists("Resources/images/" + pageType))
                                Directory.CreateDirectory("Resources/images/" + pageType);
                            //create a new ThreadedDataFetcherObject
                            var hello = htmlNode.Descendants("img").FirstOrDefault();
                            if (hello != null)
                            {

                                ThreadedDataFetcher fetcher = new ThreadedDataFetcher(new Uri("http://www.childcancer.org.nz" + htmlNode.Descendants("img").FirstOrDefault().Attributes["src"].Value), "Resources/" + imagePath);
                                //add the downloadFile method to a thread
                                var th = new Thread(fetcher.downloadFile);
                                //add the thread to the threadList
                                threadList.Add(th);
                                th.Start();
                            }
                            else
                            {
                                imagePath = "images/logoCCF.png";
                            }
                            
                        }
                        xml.Descendants("ImageList").FirstOrDefault().Add(
                            new XElement("Image", new XAttribute("node", nNode), imagePath));
                        nNode++;
                    }
                    //write all text to filesure
                    xml.WriteXml("Resources/xml/" + pageType + ".xml");

                    //join all the threads to make  they have all finished
                    foreach (var t in threadList)
                    {
                        t.Join();
                    }

                }
                catch (Exception)
                {
                    //If an Exception happens while getting data, return existing data, or Error data (create if it does not exist)
                    if (File.Exists(path))
                        return GetContentFromFile(path);
                    if (!File.Exists("Resources/xml/Error.xml"))
                    {
                        var xml = new XDocument(
                            new XElement("PageModel", new XAttribute("id", "Error"),
                                new XElement("TextList",
                                    new XElement("Text", new XAttribute("node", "1"), new XAttribute("type", "title"), "Content could not be received"),
                                    new XElement("Text", new XAttribute("node", "1"), new XAttribute("type", "info"), "Content could not be retrieved from the web. Please connect to the internet and try again."),
                                    new XElement("Text", new XAttribute("node", "1"), new XAttribute("type", "date")),
                                    new XElement("Text", new XAttribute("node", "1"), new XAttribute("type", "place"))
                                    ),
                                new XElement("ImageList"),
                                new XElement("LinksList")
                                )
                            );
                        xml.WriteXml("Resources/xml/Error.xml");
                    }
                    return GetContentFromFile("Resources/xml/Error.xml");
                }
            }
            return GetContentFromFile(path);
        }
    }
    /// <summary>
    /// This class is used solely for being able to fetch files from a url and save them to a file name very quickly
    /// Use of multiThreading
    /// </summary>
    class ThreadedDataFetcher
    {
        private Uri url;
        private String path;
        private WebClient client;
        /// <summary>
        /// create a new ThreadedDataFetcher
        /// </summary>
        /// <param name="url"> url the file has to be downloaded from</param>
        /// <param name="fileName">filename of the resulting file that is created </param>
        public ThreadedDataFetcher(Uri url, String fileName)
        {
            this.client = new WebClient();
            this.url = url;
            this.path = fileName;
        }
        public void downloadFile()
        {
            client.DownloadFile(url, path);
            client.Dispose();
        }

    }

}
