using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;
using end_user_gui.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using end_user_gui.Models.dummy;

namespace end_user_gui.Modules
{
    public class FlatLilySearchModule : ISearchModule
    {
        public List<IArchive> Search(ArchiveSearchObject searchObject)
        {
            String query = "q=";
            if (string.IsNullOrEmpty(searchObject.name))
                query += "*:*";
            else
                query += searchObject.name;

            String url = LilyUrl
                + query
                + "&wt=json"
                + "&rows=1000";

            String response = getStringResult(url);

            try
            {
                var obj = Newtonsoft.Json.Linq.JObject.Parse(response);
                var responseObject = obj["response"];
                JArray docs = responseObject["docs"] as JArray;
                var files = docs
                    .Select(
                        doc => new ArchiveFile()
                        {
                            Path = (string)doc["path"],
                            Size = long.Parse(doc["size"].ToString()),
                            Contents = (string)doc["contents"],
                            ContentType = (string)doc["contentType"],
                        } as IArchiveFile
                    )
                    .ToList();

                return files
                    .GroupBy(doc => doc.Path.Substring(0, 36))
                    .Select(grp => new Archive()
                    {
                        AipUri = grp.Key,
                        ReferenceCode = grp.Key,
                        Files = grp.ToList()
                    } as IArchive)
                    .ToList();

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IArchive Lookup(String key)
        {
            return null;
        }

        public String getStringResult(String url)
        {
            StringBuilder builder = new StringBuilder();
            try
            {
                var client = new System.Net.WebClient();
                var bytes = client.DownloadData(url);
                using (var memStr = new MemoryStream(bytes))
                {
                    using (var rd = new StreamReader(memStr, System.Text.Encoding.UTF8))
                    {
                        return rd.ReadToEnd();
                    }
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.ToString());
            }
            return string.Empty;
        }

        public const String LilyUrl = "http://earkdev.ait.ac.at:8983/solr/eark1/select?";
    }
}
