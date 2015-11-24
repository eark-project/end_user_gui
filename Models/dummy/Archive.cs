using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace end_user_gui.Models.dummy
{
    public class Archive : IArchive
    {
        public String ReferenceCode { get; set; }
        public String AipUri { get; set; }

        List<IArchiveFile> _Files = new List<IArchiveFile>();
        public List<IArchiveFile> Files
        {
            get { return _Files; }
            set { _Files = value; }
        }
    }
}
