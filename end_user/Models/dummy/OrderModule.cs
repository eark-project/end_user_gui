using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using end_user_gui.Modules;

namespace end_user_gui.Models.dummy
{
    public class OrderModule : IOrderModule
    {
        private readonly Dictionary<EndUser, List<Order>> _Orders = new Dictionary<EndUser, List<Order>>();

        public StandardReturn SubmitOrder(Order order, EndUser user)
        {
            if (order.Archives.Count > 0)
            {
                order.IssueDate = DateTime.Now;

                if (!_Orders.ContainsKey(user))
                    _Orders[user] = new List<Order>();

                _Orders[user].Add(order);

                return StandardReturn.OK();
            }
            else
            {
                return StandardReturn.InvalidInput("");
            }
        }

        public List<Order> GetUserOrders(EndUser user)
        {
            return _Orders.ContainsKey(user) ? _Orders[user] : new List<Order>();
        }
    }
}