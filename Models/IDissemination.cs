using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace end_user_gui.Models
{
    public interface IDissemination
    {
        DateTime CreatedDate { get; set; }
        String ToString();
        String KeyString;
    }
}
