using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace end_user_gui.Models
{
    public interface IOrderTarget
    {
        void Receive(Order order);
        bool IsAlive();
    }
}