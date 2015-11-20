using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using end_user_gui.Models;

namespace end_user_gui.Modules
{
    public interface IArchiveRepository
    {
        List<IDissemination> GetDIPs(IArchive archive);
        IDissemination LookupDIP(String keyString);
    }
}