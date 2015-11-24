using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace end_user_gui.Models.dummy
{
    public class ArchiveFile : IArchiveFile
    {
        public string ContentType { get; set; }
        public long Size { get; set; }
        public string Path { get; set; }
        public string Contents { get; set; }
    }
}