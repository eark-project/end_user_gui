using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace end_user_gui.Models.dummy
{
    public class SearchModule : ISearchModule
    {
        static List<IArchive> _Archives;

        public SearchModule()
        {
            if (_Archives == null)
            {
                _Archives = new List<IArchive>();

                for (int i = 0; i < 1000; i++)
                {
                    String s = i.ToString();
                    Archive arc = new Archive()
                    {
                        AipUri = String.Format("http://{0}-{1}.dk", s, Guid.NewGuid()),
                        ReferenceCode = "uuid:" + s + ""
                    };
                    _Archives.Add(arc);
                }
            }
        }

        public List<IArchive> Search(ArchiveSearchObject searchObject)
        {
            // TODO : LINQ
            List<IArchive> ret = new List<IArchive>();
            foreach (IArchive archive in _Archives)
            {
                if (searchObject.name == null || archive.ReferenceCode.Contains(searchObject.name) || archive.AipUri.Contains(searchObject.name))
                    ret.Add(archive);
            }
            return ret;
        }


        public IArchive Lookup(String key)
        {
            // TODO : LINQ
            foreach (IArchive archive in _Archives)
            {
                if (archive.ReferenceCode.Equals(key))
                    return archive;
            }
            return null;
        }
    }
}