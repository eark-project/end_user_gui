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
using System.Net;

namespace end_user_gui.Modules
{
    public class FlatLilySearchModule : IContentSearchModule
    {
        public static string CreateUrl(string query, long docStartIndex, long docBatchSize)
        {
            return LilyUrl
                + query
                + "&wt=json"
                + "&fl=path,size,contentType,package"
                + "&start=" + docStartIndex
                + "&rows=" + docBatchSize;
        }


        public List<Archive> FindArchives(String query, int targetStartIndex, int targetMaxResults)
        {
            long docStartIndex = 0, docBatchSize = 100;

            Func<string> urlMaker = () => CreateUrl(query, docStartIndex, docBatchSize);
            String response = getStringResult(urlMaker());

            try
            {
                var obj = Newtonsoft.Json.Linq.JObject.Parse(response);
                var responseObject = obj["response"];
                JArray docs = responseObject["docs"] as JArray;
                var numFound = long.Parse(responseObject["numFound"].ToString());
                var numScanned = docs.Count;

                Func<IEnumerable<JToken>, IEnumerable<IGrouping<string, JToken>>> grouper =
                    tokens => tokens.GroupBy(doc =>
                    {
                        var path = doc["path"].ToString();
                        return path.Substring(0, Math.Min(36, path.Length));
                    });

                Predicate<JToken> isValid = (t) => t["path"].ToString().Length >= 36 && t["package"] != null;

                // Add first result set
                var allDocs = new List<JToken>();
                allDocs.AddRange(docs.AsEnumerable().Where(t => isValid(t)));

                // Add more results until the desired group range has been reached
                while (grouper(allDocs).Count() <= targetStartIndex + targetMaxResults
                    && numScanned < numFound)
                {
                    docStartIndex += docBatchSize;
                    response = getStringResult(urlMaker());
                    obj = Newtonsoft.Json.Linq.JObject.Parse(response);
                    responseObject = obj["response"];
                    docs = responseObject["docs"] as JArray;
                    numScanned += docs.Count;
                    if (docs.Count == 0)
                        break;
                    allDocs.AddRange(docs.AsEnumerable().Where(t => isValid(t)));
                }

                var repo = new ArchiveRepository();
                var fileLoader = new Func<string, string, string>((refCode, path) =>
                {
                    var fileUrl = repo.FileUrl(refCode, path);
                    using (var cli = new WebClient())
                    {
                        return cli.DownloadString(fileUrl);
                    }
                });
                // Now fill the return object
                var archives = grouper(allDocs)
                    .Skip(targetStartIndex)
                    .Take(targetMaxResults)
                    .Select(grp => Archive.FromLily(grp, (refCode, path) => fileLoader(refCode, path)))
                    .ToList();

                return archives;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Archive> Search(ArchiveSearchObject searchObject)
        {
            String query = "q=";
            if (string.IsNullOrEmpty(searchObject.name))
                query += "*:*";
            else
                query += searchObject.name;

            return FindArchives(query, searchObject.StartIndex, searchObject.MaxResults);
        }

        public int SearchCount(ArchiveSearchObject searchObject)
        {
            searchObject = new ArchiveSearchObject()
            {
                StartIndex = 0,
                MaxResults = 10000,
                name = searchObject.name
            };
            return Search(searchObject).Count();
        }

        public Archive Lookup(String key)
        {
            var query = string.Format("q=package:pack_" + key);
            return FindArchives(query, 0, 1).FirstOrDefault();
        }

        private String getStringResult(String url)
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
