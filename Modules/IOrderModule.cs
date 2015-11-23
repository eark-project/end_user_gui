using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using end_user_gui.Models;

namespace end_user_gui.Modules
{
    public interface IOrderModule
    {
        StandardReturn SubmitOrder(IOrder order, IEndUser session);
        List<IOrder> GetUserOrders(IEndUser user);
    }
}