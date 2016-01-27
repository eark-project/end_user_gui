using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using end_user_gui.Models;

namespace end_user_gui.Modules
{
    public interface ISearchModule
    {
        List<Archive> Search(ArchiveSearchObject searchObject);
        int SearchCount(ArchiveSearchObject searchObject);
        Archive Lookup(String key);
    }
}