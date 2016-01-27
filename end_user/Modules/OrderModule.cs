using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using end_user_gui.Models;

namespace end_user_gui.Modules
{
    class OrderModule : IOrderModule
    {
        public List<Order> GetUserOrders(EndUser user)
        {
            using (var context = new OrderContext())
            {
                return context.Orders.Where(o => o.User.UniqueId == user.UniqueId).ToList();
            }
        }

        public StandardReturn SubmitOrder(Order order, EndUser endUser)
        {
            if (order.Archives.Count > 0)
            {
                using (var context = new OrderContext())
                {
                    order.IssueDate = DateTime.Now;
                    order.OrderUniqueID = Guid.NewGuid().ToString();
                    order.User = context.EndUsers.Where(u => u.UniqueId == endUser.UniqueId).SingleOrDefault();

                    if (order.User == null)
                        order.User = endUser;

                    try
                    {
                        context.Orders.Add(order);
                        context.SaveChanges();

                    }
                    catch (Exception ex)
                    {
                        return StandardReturn.InvalidInput("Exception");
                    }
                }
                return StandardReturn.OK();
            }
            else
            {
                return StandardReturn.InvalidInput("");
            }
        }
    }
}
