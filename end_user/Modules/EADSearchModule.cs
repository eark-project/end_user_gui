using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using end_user_gui.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace end_user_gui.Modules
{
    public class EADSearchModule : IMetadataearchModule
    {
        public const string PostUrl = "http://earkdev.ait.ac.at/exist/rest/db/apps/eark/";

        public Archive Lookup(string key)
        {
            throw new NotImplementedException();
        }

        public virtual string GetResponse(string url, string request)
        {
            using (var client = new System.Net.WebClient())
            {
                var respString = client.UploadString(url, request);
                return respString;
            }
        }
        public List<Archive> Search(ArchiveSearchObject searchObject)
        {
            var request = Properties.Resources.EADSearch;
            request = request.Replace("<title>", searchObject.name.Replace("'", "''"))
                .Replace("<description>", searchObject.Description);
            var filters = new List<string>();

            if (searchObject.SearchInTitle)
                filters.Add("contains(upper-case($title//text()), upper-case($titleQuery))");
            if (searchObject.SearchInDescription)
                filters.Add("contains(upper-case($archDescNode//text()), upper-case($titleQuery))");


            request = request.Replace(
                "<query>",
                string.Join(
                    " or ",
                    filters.ToArray()
                    ));

            var response = JObject.Parse(GetResponse(PostUrl, request));
            var responseData = response["data"];
            var responseArray = responseData is JArray ? responseData as JArray
                : responseData.Count() > 0 ? new JArray(responseData) : new JArray();

            var ret = responseArray
                .Select(pkg => new Archive()
                {
                    AipUri = pkg["id"].ToString(),
                    ReferenceCode = pkg["id"].ToString(),
                    Files = new List<ArchiveFile>(),
                    Metadata = new ArchiveMetadata()
                    {
                        Title = pkg["title"].ToString(),
                        Description = pkg["description"].ToString(),
                        //CreatedBy = "",
                        //CreatedDate = new DateTime(),
                        //Format = ArchiveFormat.other,
                        //Type = ArchiveType.AIP
                    }
                })
                .ToList();
            return ret;
        }

        public int SearchCount(ArchiveSearchObject searchObject)
        {
            return Search(searchObject).Count;
        }
    }
}