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
    }
}