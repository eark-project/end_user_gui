package models.dummy;

import models.*;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

/**
 * Created by Beemen on 04/08/2015.
 */
public class OrderModule implements IOrderModule {

    private final List<IOrder> _Orders = new ArrayList<>();

    @Override
    public StandardReturn SubmitOrder(IOrder order, ISession sesion) {
        if(order.Archives().size() > 0){
            order.IssueDate(new Date());
            _Orders.add(order);
            sesion.NewOrder();
            return StandardReturn.OK();
        }
        else {
            return StandardReturn.InvalidInput("");
        }
    }

    @Override
    public List<IOrder> GetUserOrders(IEndUser user) {
        return _Orders.subList(0, _Orders.size()-1);
    }


}
