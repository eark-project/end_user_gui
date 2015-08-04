package models.dummy;

import models.*;

import java.util.*;

/**
 * Created by Beemen on 04/08/2015.
 */
public class OrderModule implements IOrderModule {

    private final HashMap<IEndUser,List<IOrder>>_Orders = new HashMap<>();

    @Override
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

    @Override
    public List<IOrder> GetUserOrders(IEndUser user) {
        return _Orders.getOrDefault(user, new ArrayList<>());
    }
}
