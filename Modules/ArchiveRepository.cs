using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using end_user_gui.Models;

namespace end_user_gui.Modules
{
    public class ArchiveRepository : IArchiveRepository
    {
        public static readonly string BaseUrl = "http://earkdev.ait.ac.at:12060/repository/table/eark1/record/USER.";
        public static readonly string Suffix = "/field/n$content/data?ns.n=org.eu.eark";

        public List<Models.Dissemination> GetDIPs(Models.Archive archive)
        {
            // No DIPs available for now - keep empty
            return new List<Models.Dissemination>();
        }

        public Models.Dissemination LookupDIP(string keyString)
        {
            // No DIPs available for now - keep null
            return null;
        }

        public string FileUrl(string referenceCode, string path)
        {
            var url = string.Format("{0}{1}{2}{3}",
                BaseUrl,
                referenceCode,
                HttpUtility.UrlEncode(path.Replace(".", "\\.")),
                Suffix
                );
            return url;
        }

        public Models.ArchiveFile LoadFile(string referenceCode, string path)
        {
            var url = FileUrl(referenceCode, path);
            var client = new WebClient();
            var data = client.DownloadData(url);
            return new ArchiveFile()
            {
                Contents = data,
                ContentType = "",
                Size = data.Length,
                Path = path
            };
        }
    }
}