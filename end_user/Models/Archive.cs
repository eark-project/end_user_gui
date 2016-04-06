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
                ret.Metadata = ArchiveMetadata.FromEAD(xml);
            }
            return ret;
        }
    }
}