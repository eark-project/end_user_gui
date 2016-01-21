using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace end_user_gui.Models
{
    public class OrderArchiveReference
    {
        public Archive Archive { get; set; }
        public Dissemination Dissemination { get; set; }
        public String LevelOfDescription { get; set; }
        public DateTime AccessEndDate { get; set; }
        public OrderStatus Status { get; set; }
        public AccessRestriction AccessRestriction { get; set; }
    }
}