using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace end_user_gui.Models
{
    public interface IDissemination
    {
        Date CreatedDate();
        void CreatedDate(Date value);

        String ToString();
        String KeyString();
    }
