package ui;

import models.IEndUser;
import models.IOrder;
import models.ISession;

/**
 * Created by Beemen on 30/07/2015.
 */
public class PlaySession implements ISession {

    public IOrder _CurrentOrder;
    public IOrder CurrentOrder(){return _CurrentOrder;}

    public IEndUser _User;
    public IEndUser User(){return  _User;}

    private play.mvc.Http.Session _Session;

    public static PlaySession Current(){
        PlaySession ret = new PlaySession();
        ret._Session = play.mvc.Http.Context.current().session();
        return ret;
    }


}
