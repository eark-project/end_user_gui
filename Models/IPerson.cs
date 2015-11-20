using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace end_user_gui.Models
{
    public interface IPerson
    {
        String Name { get; set; }
        String UniqueId { get; set; }
    }
}