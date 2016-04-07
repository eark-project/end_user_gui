using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace end_user_gui.Models
{
    /// <summary>
    /// TODO: Fill this from EAD content in /metadata.xml file (if available)
    /// </summary>
    public class ArchiveMetadata
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public ArchiveType Type { get; set; } = ArchiveType.AIP;
        public ArchiveFormat Format { get; set; } = ArchiveFormat.mixed;

        public static ArchiveMetadata FromEAD(string xml)
        {

            var doc = new XmlDocument();
            doc.LoadXml(xml);
            var nsMgr = new XmlNamespaceManager(doc.NameTable);
            nsMgr.AddNamespace("ead", "urn:isbn:1-931666-22-9");
            return new ArchiveMetadata()
            {
                Title = doc.SelectSingleNode("//ead:eadheader//ead:titleproper", nsMgr).InnerText,
                Description = doc.SelectSingleNode("//ead:archdesc/ead:bioghist", nsMgr).InnerText
            };
        }
    }
}
