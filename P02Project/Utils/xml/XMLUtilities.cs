using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.IO;
using System.Web;
using HtmlAgilityPack;

namespace P02Project.Resources.xml
{


  


    class XMLUtilities
    {




        public static PageModel GetContentFromFile(String filePath)
        {
            PageModel xmlContent;
            XmlSerializer mySerializer = new XmlSerializer(typeof(PageModel));
           
            FileStream myFileStream = new FileStream(filePath, FileMode.Open);

            xmlContent = (PageModel)mySerializer.Deserialize(myFileStream);
            myFileStream.Close();

            return xmlContent;

        }

        public static PageModel GetContentFromPage(string url)
        {
            var pageType = url.Split('/').LastOrDefault().Split('.').FirstOrDefault();
            var path = Path.Combine(Path.GetFullPath("."), "Resources/xml/" + pageType + ".xml");
            if (!File.Exists(path) 
                || File.GetLastWriteTimeUtc(path) > DateTime.UtcNow.Subtract(new TimeSpan(12, 0, 0)))
            {
                var html = new HtmlWeb();
                var page = html.Load(url);
                var itemList =
                    page.GetElementbyId("contentPrimary").Elements("div").Where(
                        node => node.Attributes["class"].Value == "item").ToList();

                var textList = "<TextList>\n";
                var imageList = "<ImageList>\n";
                var linksList = "<LinksList>\n";
                var n = 1;
                foreach (var node in itemList)
                {
                    textList += "<Text node=\"" + n + "\" type=\"title\">" +
                                node.Descendants("a").FirstOrDefault().InnerText + "</Text>\n";
                    textList += "<Text node=\"" + n + "\" type=\"info\">" +
                                node.Descendants("p").FirstOrDefault().InnerText + "</Text>\n";
                    if (pageType == "Events")
                    {
                        var content = node.Descendants("small").FirstOrDefault().InnerText;
                        textList += "<Text node=\"" + n + "\" type=\"date\">" +
                                    content.Substring(6, content.IndexOf("Where: ") - 6) + "</Text>\n";
                        textList += "<Text node=\"" + n + "\" type=\"place\">" +
                                    content.Substring(content.IndexOf("Where: ") + 7) + "</Text>\n";
                    }
                    else
                    {
                        textList += "<Text node=\"" + n + "\" type=\"date\">" +
                                    node.Descendants("small").FirstOrDefault().InnerText + "</Text>\n";
                    }
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
                File.WriteAllText(path, xml);
            }
            return GetContentFromFile(path);
        }
    }


   
    
}
