using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;

namespace TmxTool.Model
{
    public class TmxRow
    {
        public string Source { get; set; }
        public string Target { get; set; }
        public string TargetLanguage { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string LastUsedDate { get; set; }

        public TmxRow(List<XElement> nodeItem) {
            Source = nodeItem[0].XPathSelectElement(XmlNodes.SegmentText).Value.ToString();
            Target = nodeItem[1].XPathSelectElement(XmlNodes.SegmentText).Value.ToString();
            TargetLanguage = nodeItem[1].FirstAttribute.Value.ToString();
            CreatedDate = nodeItem[1].Attribute(XmlNodes.CreationDate).Value.ToString();
            CreatedBy = nodeItem[1].Attribute(XmlNodes.CreatedBy).Value.ToString();
            LastUsedDate = nodeItem[1].Attribute(XmlNodes.LastUsedDate).Value.ToString();             
            //nodeItem[1].Attribute("changedate").Value.ToString();             
            //nodeItem[1].Attribute("changeid").Value.ToString();      

        }
        private static class XmlNodes
        {
            public const string SegmentText = "seg";
            public const string CreationDate = "creationdate";
            public const string CreatedBy = "creationid";
            public const string LastUsedDate = "lastusagedate";

        }

    }
}
