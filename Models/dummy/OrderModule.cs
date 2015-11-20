using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace end_user_gui.Models.dummy
{
public class OrderModule : IOrderModule {

    private final HashMap<IEndUser,List<IOrder>>_Orders = new HashMap<>();

    public StandardReturn SubmitOrder(IOrder order, IEndUser user) {
        if(order.Archives().size() > 0){
            order.IssueDate(new Date());

            _Orders.putIfAbsent(user, new ArrayList<>());
            _Orders.get(user).add(order);

            return StandardReturn.OK();
        }
        else {
            return StandardReturn.InvalidInput("");
        }
    }

    public List<IOrder> GetUserOrders(IEndUser user) {
        return _Orders.getOrDefault(user, new ArrayList<>());
    }
}
}