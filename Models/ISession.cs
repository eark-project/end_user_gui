using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace end_user_gui.Models
{
    public interface ISession
    {
        IOrder CurrentOrder { get; }
        void NewOrder();
        IEndUser User {get;}
    }
}