package controllers;

import play.libs.Json;
import models.ArchiveSearchObject;
import modules.Environment;
import models.IArchive;
import play.mvc.Result;
import play.data.Form;
import play.mvc.Controller;
import views.html.searchresultview;

import java.util.List;

/**
 * Created by Beemen on 30/07/2015.
 */
public class SearchController extends Controller{

    public Result Search(){
        Form<ArchiveSearchObject> form = Form.form(ArchiveSearchObject.class);
        form = form.bindFromRequest();
        ArchiveSearchObject searchObject = form.get();
        List<IArchive> searchResults = Environment.Current().SearchModule().Search(searchObject);
        return ok(searchresultview.render(searchResults));
    }

    public Result AutoComplete(String query){
        ArchiveSearchObject searchObject = new ArchiveSearchObject();
        searchObject.name = query;

        List<IArchive> searchResults = Environment.Current().SearchModule().Search(searchObject);
        String[] ret = new String[searchResults.size()];
        for(int i=0; i<searchResults.size(); i++){
            ret[i] = searchResults.get(i).ReferenceCode();
        }
        return ok(Json.toJson(ret));

    }
}
