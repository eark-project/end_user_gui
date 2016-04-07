using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace end_user_gui.Models
{
    public class Metadata
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public string UnitDate { get; set; }
    }

    public class FileMetadata : Metadata
    {
        public FileMetadata(XmlNode didNode)
        {
            XmlNamespaceManager nsMgr = new XmlNamespaceManager(didNode.OwnerDocument.NameTable);
            nsMgr.AddNamespace("ead", "urn:isbn:1-931666-22-9");

            Title = didNode.SelectSingleNode("ead:unittitle", nsMgr)?.InnerText;
            Description = didNode.SelectSingleNode("ead:dao/ead:daodesc", nsMgr)?.InnerText;
            CreatedBy = didNode.SelectSingleNode("ead:origination", nsMgr)?.InnerText;
            UnitDate = didNode.SelectSingleNode("ead:unitdate", nsMgr)?.InnerText;
        }
    }

    /// <summary>
    /// TODO: Fill this from EAD content in /metadata.xml file (if available)
    /// </summary>
    public class ArchiveMetadata : Metadata
    {
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
                Description = doc.SelectSingleNode("//ead:archdesc/ead:bioghist", nsMgr).InnerText,
                CreatedBy = doc.SelectSingleNode("//ead:archdesc/ead:did/ead:origination", nsMgr).InnerText,
                UnitDate = doc.SelectSingleNode("//ead:archdesc/ead:did/ead:unitdate", nsMgr).InnerText,
            };
        }
    }
}
