using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace end_user_gui.Models
{
    public class OrderArchiveReference
    {
        public IArchive Archive;
        public IDissemination Dissemination;
        public String LevelOfDescription;
        public Date AccessEndDate;
        public OrderStatus Status;
        public AccessRestriction AccessRestriction;
    }
}