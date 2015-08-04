package ui;

import models.IEndUser;
import models.IOrder;
import models.ISession;
import models.dummy.DummyOrder;
import play.mvc.Http;

import javax.persistence.criteria.Order;

/**
 * Created by Beemen on 30/07/2015.
 */
public class PlaySession implements ISession {

    public IOrder CurrentOrder(){
        String key = orderKey();
        Object ret = play.cache.Cache.get(key);
        if(ret == null){
            NewOrder();
        }
        return (IOrder)ret;
    }

    @Override
    public void NewOrder() {
        play.cache.Cache.set(
                orderKey(),
                new DummyOrder(){{
                    User(this.User());
                }}
        );
    }

    public String SessionId(){
        Http.Session session = Http.Context.current().session();

        String uuid = session.get("uuid");
        if (uuid == null) {
            uuid = java.util.UUID.randomUUID().toString();
            session.put("uuid", uuid);
        }
        return uuid;
    }

    String orderKey(){
        return SessionId() + "_CurrentOrder";
    }

    public IEndUser _User;
    public IEndUser User(){return  _User;}

    private play.mvc.Http.Session _Session;

    public static PlaySession Current(){
        PlaySession ret = new PlaySession();
        ret._Session = play.mvc.Http.Context.current().session();
        return ret;
    }


}
