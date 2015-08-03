package controllers;

import models.Environment;
import models.IArchive;
import play.mvc.Result;
import views.html.cartviewbody;

/**
 * Created by Beemen on 30/07/2015.
 */
public class OrderController extends play.mvc.Controller {
    public Result View(){
        return ok(cartviewbody.render(Environment.Current().Session().CurrentOrder()));
    }

    public Result Count(){
        int c = Environment.Current().Session().CurrentOrder().Archives().size();
        String s = "";
        if(c>0)
            s = "(" + new Integer(c).toString()  + ")";

        return ok(s);
    }

    public Result Empty(){
        Environment.Current().Session().CurrentOrder().Archives().clear();
        return ok();
    }

    public Result Add(String key, String commnets){
        IArchive archive = Environment.Current().SearchModule().Lookup(key);
        Environment.Current().Session().CurrentOrder().Add(archive);
        return ok();
    }

    public Result Remove(String key){
        IArchive archive = Environment.Current().SearchModule().Lookup(key);
        Environment.Current().Session().CurrentOrder().Remove(archive);
        return ok();
    }

    public Result Submit(){
        throw new UnsupportedOperationException();
    }

}
