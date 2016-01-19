﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;

namespace end_user_gui.Modules
{
    public class ArchiveRepository : IArchiveRepository
    {
        public static readonly string BaseUrl = "http://earkdev.ait.ac.at:12060/repository/table/eark1/record/USER.";
        public static readonly string Suffix = "/field/n$content/data?ns.n=org.eu.eark";

        public List<Models.IDissemination> GetDIPs(Models.IArchive archive)
        {
            // No DIPs available for now - keep empty
            return new List<Models.IDissemination>();
        }

        public Models.IDissemination LookupDIP(string keyString)
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

        public Models.IArchiveFile LoadFile(string referenceCode, string path)
        {
            var url = FileUrl(referenceCode, path);
            var client = new WebClient();
            var data = client.DownloadData(url);
            return new Models.dummy.ArchiveFile()
            {
                Contents = data,
                ContentType = "",
                Size = data.Length,
                Path = path
            };
        }
    }
}