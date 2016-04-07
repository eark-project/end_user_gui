using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Xml;

namespace end_user_gui.Models
{
    [ComplexType]
    public class Archive
    {
        public String ReferenceCode { get; set; }
        public String AipUri { get; set; }
        public List<ArchiveFile> Files { get; set; }

        [NotMapped]
        public ArchiveMetadata Metadata { get; set; }

        public static Archive FromLily(IGrouping<string, JToken> grp, Func<string, string, string> fileDownloader)
        {
            var ret = new Archive()
            {
                AipUri = grp.Key,
                ReferenceCode = grp.Key,
                Metadata = new ArchiveMetadata()
                {
                    Title = grp.Key,
                    Description = "",
                    //CreatedBy = "",
                    //CreatedDate = new DateTime(),
                    //Type = ArchiveType.AIP,
                    //Format = ArchiveFormat.other
                },
                Files = grp.Select(
                            doc => new ArchiveFile()
                            {
                                Path = doc["path"].ToString().Substring(grp.Key.Length),
                                Size = long.Parse(doc["size"].ToString()),
                                //Contents = (string)doc["contents"],
                                ContentType = (string)doc["contentType"],
                            } as ArchiveFile)
                        .ToList()
            };

            // Try to fill from EAD - if there is one
            var mainEad = ret.Files.Where(f => f.Type == FileTypes.EAD)
                .OrderBy(f => f.Path.Split('\\', '/').Length)
                .ThenBy(f => f.Path)
                .FirstOrDefault();

            if (mainEad != null)
            {
                var xml = fileDownloader(ret.ReferenceCode, mainEad.Path);
                var eadDoc = new XmlDocument();
                eadDoc.LoadXml(xml);

                ret.Metadata = ArchiveMetadata.FromEAD(xml);

                XmlNamespaceManager nsMgr = new XmlNamespaceManager(eadDoc.NameTable);
                nsMgr.AddNamespace("ead", "urn:isbn:1-931666-22-9");
                nsMgr.AddNamespace("xlink", "http://www.w3.org/1999/xlink");

                Func<string, string> uriConverter = (didUrl) =>
                 {
                     if (didUrl.StartsWith("file://"))
                         didUrl = didUrl.Substring(7);

                     var eadUrl = mainEad.Path;
                     eadUrl = eadUrl.Substring(0, eadUrl.LastIndexOf('/'));
                     while (didUrl.StartsWith("../"))
                     {
                         eadUrl = eadUrl.Substring(0, eadUrl.LastIndexOf('/'));
                         didUrl = didUrl.Substring(3);
                     }
                     return eadUrl + '/' + didUrl;
                 };

                var xPath = "//*[@level='file']/ead:did [ ead:dao [ string-length(@xlink:href) > 0 ]]";
                var didNodes = eadDoc.SelectNodes(xPath, nsMgr).OfType<XmlElement>().Select(
                        nd => new
                        {
                            Path = uriConverter(nd.SelectSingleNode("ead:dao/@xlink:href", nsMgr).Value),
                            Node = nd
                        }
                    ).ToArray();

                var joined = from didNode in didNodes
                             join file in ret.Files
                             on didNode.Path equals file.Path
                             select new { didNode, file };

                foreach (var j in joined)
                {
                    j.file.Metadata = new FileMetadata(j.didNode.Node);
                }
            }
            return ret;
        }
    }
}