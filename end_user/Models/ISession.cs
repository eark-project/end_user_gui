using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace end_user_gui.Models
{
    public interface ISession
    {
        Order CurrentOrder { get; }
        void NewOrder();
        EndUser User {get;}
    }
}