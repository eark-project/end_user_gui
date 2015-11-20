using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using end_user_gui.Models;

namespace end_user_gui.Modules
{
    public interface ISearchModule
    {
        List<IArchive> Search(ArchiveSearchObject searchObject);
        IArchive Lookup(String key);
    }
}