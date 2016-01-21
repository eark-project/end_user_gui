using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace end_user_gui.Models
{
    public class Archive
    {
        public String ReferenceCode { get; set; }
        public String AipUri { get; set; }
        public List<ArchiveFile> Files { get; set; }
    }
}