using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TMS_Servers
{
    public class AutocompleteBoxSourceCreator
    {

         public static List<string> LoadList(IEnumerable<XElement> sourceCollection)
        {
            List<string> listToAddTo = new List<string>();
            foreach (XElement node in sourceCollection)
            {
                listToAddTo.Add(node.Element("name").Value);
            }
            return listToAddTo;
        }
    }
}
