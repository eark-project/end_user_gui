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
        string CreateUrl(string query, long docStartIndex, long docBatchSize)
        {
            return LilyUrl
                + query
                + "&wt=json"
                + "&fl=path,size,contentType"
                + "&start=" + docStartIndex
                + "&rows=" + docBatchSize;
        }


        private List<IArchive> FindArchives(String query, int targetStartIndex, int targetMaxResults)
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

                // Add first result set
                var allDocs = new List<JToken>();
                allDocs.AddRange(docs.AsEnumerable());

                Func<IEnumerable<JToken>, IEnumerable<IGrouping<string, JToken>>> grouper =
                    tokens => tokens.GroupBy(doc =>
                    {
                        var path = doc["path"].ToString();
                        return path.Substring(0, Math.Min(36, path.Length));
                    });

                // Add more results until the desired group range has been reached
                while (grouper(allDocs).Count() <= targetStartIndex + targetMaxResults
                    && allDocs.Count < numFound)
                {
                    docStartIndex += docBatchSize;
                    response = getStringResult(urlMaker());
                    obj = Newtonsoft.Json.Linq.JObject.Parse(response);
                    responseObject = obj["response"];
                    docs = responseObject["docs"] as JArray;
                    allDocs.AddRange(docs.AsEnumerable());
                }

                // Now fill the return object
                var archives = grouper(allDocs)
                    .Skip(targetStartIndex)
                    .Take(targetMaxResults)
                    .Select(grp => new Archive()
                    {
                        AipUri = grp.Key,
                        ReferenceCode = grp.Key,
                        Files = grp.Select(
                            doc => new ArchiveFile()
                            {
                                Path = doc["path"].ToString().Substring(grp.Key.Length),
                                Size = long.Parse(doc["size"].ToString()),
                                //Contents = (string)doc["contents"],
                                ContentType = (string)doc["contentType"],
                            } as IArchiveFile)
                        .ToList()
                    } as IArchive)
                    .ToList();

                return archives;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<IArchive> Search(ArchiveSearchObject searchObject)
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

        public IArchive Lookup(String key)
        {
            var query = string.Format("q=path:{0}", key);
            return FindArchives(query, 0, 1).FirstOrDefault();
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
