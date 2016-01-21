using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using end_user_gui.Modules;

namespace end_user_gui.Models.dummy
{
    public class SearchModule : ISearchModule
    {
        static List<Archive> _Archives;

        public SearchModule()
        {
            if (_Archives == null)
            {
                _Archives = new List<Archive>();

                for (int i = 0; i < 1000; i++)
                {
                    String s = i.ToString();
                    Archive arc = new Archive()
                    {
                        AipUri = String.Format("http://{0}-{1}.dk", s, Guid.NewGuid()),
                        ReferenceCode = "uuid_" + s + ""
                    };
                    _Archives.Add(arc);
                }
            }
        }

        public List<Archive> Search(ArchiveSearchObject searchObject)
        {
            // TODO : LINQ
            List<Archive> ret = new List<Archive>();
            foreach (Archive archive in _Archives)
            {
                if (searchObject.name == null || archive.ReferenceCode.Contains(searchObject.name) || archive.AipUri.Contains(searchObject.name))
                    ret.Add(archive);
            }
            return ret;
        }


        public Archive Lookup(String key)
        {
            // TODO : LINQ
            foreach (Archive archive in _Archives)
            {
                if (archive.ReferenceCode.Equals(key))
                    return archive;
            }
            return null;
        }


        public int SearchCount(ArchiveSearchObject searchObject)
        {
            return _Archives.Count;
        }
    }
}