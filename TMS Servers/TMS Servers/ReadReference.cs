using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;

namespace TMS_Servers
{
    public class ReadReference
    {
       

        public static IEnumerable<XElement> ReadFile(string doc, string xpath)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            
            using (Stream stream = asm.GetManifestResourceStream(doc))            
            using (StreamReader reader = new StreamReader(stream))
            {
                string document = reader.ReadToEnd();                    
                IEnumerable<XElement> Xdoc = XDocument.Parse(document).XPathSelectElements(xpath);
                return Xdoc;
            }

            
            
            
        }
    }
       
}
