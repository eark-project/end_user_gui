package modules;

import models.IEndUser;
import models.IOrder;
import models.StandardReturn;

import java.util.List;

/**
 * Created by Beemen on 04/08/2015.
 */
public interface IOrderModule {
    StandardReturn SubmitOrder(IOrder order, IEndUser session);
    List<IOrder> GetUserOrders(IEndUser user);
}
