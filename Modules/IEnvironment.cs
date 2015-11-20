using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace end_user_gui.Modules
{
    public interface IEnvironment
    {
        ISearchModule SearchModule();
        IOrderModule OrderModule();
        IArchiveRepository ArchiveRepository();
        ISession Session();
    }
}