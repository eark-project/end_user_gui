using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using end_user_gui.Modules;
using System.Text.RegularExpressions;

namespace end_user_gui.Models.dummy
{
    public class ArchiveRepository : IArchiveRepository
    {
        Random _RandomGenerator = new Random();

        Dissemination CreateDissemination()
        {
            DateTime cal = new DateTime(_RandomGenerator.Next(1900, 2015), _RandomGenerator.Next(1, 12), _RandomGenerator.Next(1, 28));
            return new Dissemination()
            {
                CreatedDate = cal,
                _DummyDescription = new NLipsum.Core.Paragraph(1, 10).ToString()
            };
        }

        public List<IDissemination> GetDIPs(IArchive archive)
        {
            string p = "[0-9]+";
            String inp = archive.ReferenceCode;
            String s = "";
            foreach (var m in Regex.Matches(inp, p))
            {
                s += m.ToString();
            }
            var c = int.Parse(s) % 3;

            var ret = new List<IDissemination>();
            for (int i = 0; i < c; i++)
            {
                ret.Add(CreateDissemination());
            }
            return ret;
        }

        public IDissemination LookupDIP(String keyString)
        {
            return CreateDissemination();
        }


        public string FileUrl(string referenceCode, string path)
        {
            throw new NotImplementedException();
        }
    }
}