package controllers;

import models.Environment;
import models.IArchive;
import models.IDissemination;
import models.StandardReturn;
import play.mvc.Result;
import views.html.addtocartmodal_body;
import views.html.cartview_body;

import java.util.List;

/**
 * Created by Beemen on 30/07/2015.
 */
public class OrderController extends play.mvc.Controller {
    public Result View(){
        return ok(cartview_body.render(Environment.Current().Session().CurrentOrder()));
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

    public Result OpenAddDialog(String key){
        IArchive archive = Environment.Current().SearchModule().Lookup(key);
        List<IDissemination> ret = Environment.Current().ArchiveRepository().GetDIPs(archive);
        return ok(addtocartmodal_body.render(archive, ret));
    }

    public Result Add(String key, String disKey, String commnets){
        IArchive archive = Environment.Current().SearchModule().Lookup(key);
        IDissemination dissemination = null;
        if(disKey != null && disKey.length()>0){
            dissemination = Environment.Current().ArchiveRepository().LookupDIP(disKey);
        }
        Environment.Current().Session().CurrentOrder().Add(archive, dissemination);
        return ok();
    }

    public Result Remove(String key){
        IArchive archive = Environment.Current().SearchModule().Lookup(key);
        Environment.Current().Session().CurrentOrder().Remove(archive);
        return ok();
    }

    public Result Submit(){

        StandardReturn ret = Environment.Current().OrderModule().SubmitOrder(
                Environment.Current().Session().CurrentOrder(),
                Environment.Current().Session().User()
        );
        if(ret.Succeeded){
            Environment.Current().Session().NewOrder();
        }
        return ok(ret.toString());
    }

}
