using System;
using System.Linq;
using System.Net;
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
            using (var myFileStream = new FileStream(filePath, FileMode.Open)) {
                xmlContent = (PageModel) mySerializer.Deserialize(myFileStream);
            }

            return xmlContent;

        }

        public static PageModel GetContentFromPage(string url)
        {
            var pageType = url.Split('/').LastOrDefault().Split('.').FirstOrDefault();
            var path = "Resources/xml/" + pageType + ".xml";
            //If the requested file doesn't exist, or if the file is more than 12 hours old, try getting new file
            if (!File.Exists(path) 
                || File.GetLastWriteTimeUtc(path) > DateTime.UtcNow.Subtract(new TimeSpan(12, 0, 0)))
            {

                try {
                    List<Thread> threadList = new List<Thread>();
                    var html = new HtmlWeb();
                    var page = html.Load(url);
                    var itemList =
                        page.GetElementbyId("contentPrimary").Elements("div").Where(
                            node => node.Attributes["class"].Value == "item").ToList();

                    var textList = "<TextList>\n";
                    var imageList = "<ImageList>\n";
                    var linksList = "<LinksList>\n";
                    var n = 1;
                    foreach (var node in itemList) {
                        textList += "<Text node=\"" + n + "\" type=\"title\">" +
                                    node.Descendants("a").FirstOrDefault().InnerText + "</Text>\n";
                        textList += "<Text node=\"" + n + "\" type=\"info\">" +
                                    node.Descendants("p").FirstOrDefault().InnerText + "</Text>\n";
                        if (pageType == "Events") {
                            var content = node.Descendants("small").FirstOrDefault().InnerText;
                            textList += "<Text node=\"" + n + "\" type=\"date\">" +
                                        content.Substring(0, content.IndexOf("Where: ")) + "</Text>\n";
                            textList += "<Text node=\"" + n + "\" type=\"place\">" +
                                        content.Substring(content.IndexOf("Where: ")) + "</Text>\n";
                        } else {
                            textList += "<Text node=\"" + n + "\" type=\"date\">" +
                                        node.Descendants("small").FirstOrDefault().InnerText + "</Text>\n";
                        }
                        var imagePath = "images/" + pageType + "/" + node.Descendants("a").FirstOrDefault().InnerText.Replace("/", "-").Replace("\\", "-").Replace(" ", "") + ".jpg";
                        imagePath = imagePath.Replace(":", " -");
                        if (!File.Exists("Resources/" + imagePath)) {
                            if (!Directory.Exists("Resources/images/" + pageType))
                                Directory.CreateDirectory("Resources/images/" + pageType);
                            ThreadedDataFetcher fetcer = new ThreadedDataFetcher(new Uri("http://www.childcancer.org.nz" + node.Descendants("img").FirstOrDefault().Attributes["src"].Value), "Resources/" + imagePath);
                            Thread th = new Thread(new ThreadStart(fetcer.downloadFile));
                            threadList.Add(th);
                            th.Start();
                            //while downloading is occurring, do everything else you need to do
                            //at the end make sure you join all the threads
                            //add threads to table of threads;
                        }
                        imageList += "<Image node=\"" + n + "\">" + imagePath + "</Image>\n";
                        n++;
                    }
                    textList += "</TextList>\n";
                    imageList += "</ImageList>\n";
                    linksList += "</LinksList>\n";
                    var xml = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>\n"
                              + "<PageModel id =\"" + pageType + "\">\n"
                              + textList + "\n"
                              + imageList + "\n"
                              + linksList + "\n"
                              + "</PageModel>";
                    xml = xml.Replace("&", "and");
                    //join all the threads to make sure they have all finished
                    foreach (Thread t in threadList)
                    {
                        t.Join();
                    }
                    File.WriteAllText(path, xml);
                } catch (Exception)
                {
                    if (File.Exists(path))
                        return GetContentFromFile(path);
                    if (File.Exists("Resources/xml/Error.xml"))
                    {
                        var xml = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>"
                                  + "<!--Can store information regarding, text images, links-->\n"
                                  + "<PageModel id=\"Error\">\n"
                                  + "    <TextList>\n"
                                  + "        <Text node=\"1\" type=\"title\">Content could not be received</Text>\n"
                                  + "        <Text node=\"1\" type=\"info\">Content could not be retrieved from the web. Please connect to the internet and try again.</Text>\n"
                                  + "        <Text node=\"1\" type=\"date\"></Text>\n"
                                  + "        <Text node=\"1\" type=\"place\"></Text>\n"
                                  + "    </TextList>\n"
                                  + "    <ImageList>\n"
                                  + "    </ImageList>\n"
                                  + "    <LinksList>\n"
                                  + "    </LinksList>\n"
                                  + "</PageModel>";
                        File.WriteAllText("Resources/xml/Error.xml", xml);
                    }
                    return GetContentFromFile("Resources/xml/Error.xml");
                }
            }
            return GetContentFromFile(path);
        }
    }

    class ThreadedDataFetcher
    {
        private Uri url;
        private String path;
        private static WebClient client = new WebClient();
        public ThreadedDataFetcher(Uri url, String fileName)
        {
            this.url = url;
            this.path = fileName;
        }
        public void downloadFile()
        {
            client.DownloadFileAsync(url, path);
        }
    }

}
