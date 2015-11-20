using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace end_user_gui.Models.dummy
{
    public class EndUser : IEndUser
    {
        public String Name { get; set; }
        public String UniqueId { get; set; }
    }
}