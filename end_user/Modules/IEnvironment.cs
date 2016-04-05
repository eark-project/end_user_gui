using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using end_user_gui.Models;

namespace end_user_gui.Modules
{
    public interface IEnvironment
    {
        ISearchModule ContentSearchModule();
        ISearchModule MetadataSearchModule();
        IOrderModule OrderModule();
        IArchiveRepository ArchiveRepository();
        ISession Session();
    }
}