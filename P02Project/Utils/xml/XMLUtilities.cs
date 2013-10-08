using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace P02Project.Resources.xml
{


  


    class XMLUtilities
    {




        public static Content GetContentFromFile(String filename)
        {
            Content xmlContent;
            XmlSerializer mySerializer = new XmlSerializer(typeof(Content));
            String path= Path.Combine(Path.GetFullPath("."), "Resources/xml/Content.xml");
            FileStream myFileStream = new FileStream(path, FileMode.Open);

            xmlContent = (Content)mySerializer.Deserialize(myFileStream);

            return xmlContent;

        }
    }


   
    
}
