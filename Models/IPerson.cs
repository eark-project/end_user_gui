using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace end_user_gui.Models
{
    public interface IPerson
    {
        String Name();
        void Name(String value);

        String UniqueId();
        void UniqueId(String value);
    }
}