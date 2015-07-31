package util;

import akka.io.IO;
import models.IOrder;

/**
 * Created by Beemen on 29/07/2015.
 */
public interface IOrderSerializer {
    String Serialize(IOrder order);
    IOrder Deserialize(String orderXml);
}
