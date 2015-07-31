package models;

/**
 * Created by Beemen on 29/07/2015.
 */
public interface IOrderTarget {
    void Receive(IOrder order);
    boolean IsAlive();
}
