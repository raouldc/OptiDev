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




        public static PageModel GetContentFromFile(String filePath)
        {
            PageModel xmlContent;
            XmlSerializer mySerializer = new XmlSerializer(typeof(PageModel));
           
            FileStream myFileStream = new FileStream(filePath, FileMode.Open);

            xmlContent = (PageModel)mySerializer.Deserialize(myFileStream);
            myFileStream.Close();

            return xmlContent;

        }
    }


   
    
}
