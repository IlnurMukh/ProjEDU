using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ProjEDU.Model
{
    public class Content
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string XMLText { get; set; }

        public static string ToString(XmlDocument doc)
        {
            return doc.OuterXml;
        }

        public static XmlDocument ToXml(string str)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(str);
            return doc;
        }
    }
}
