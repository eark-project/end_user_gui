using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using end_user_gui.Models;

namespace end_user_gui.Modules
{
    public interface IArchiveRepository
    {
        List<IDissemination> GetDIPs(Archive archive);
        IDissemination LookupDIP(String keyString);
        string FileUrl(string referenceCode, string path);
    }
}