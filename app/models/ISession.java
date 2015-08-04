package models;

/**
 * Created by Beemen on 30/07/2015.
 */
public interface ISession {
    IOrder CurrentOrder();
    void NewOrder();
    IEndUser User();
}
