using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

/**
 * Created by Beemen on 30/07/2015.
 */

namespace end_user_gui.Controllers
{
    public class SearchController : Controller
    {
        public ActionResult Search()
        {
            Form<ArchiveSearchObject> form = Form.form(ArchiveSearchObject.class);
            form = form.bindFromRequest();
            ArchiveSearchObject searchObject = form.get();
            List<IArchive> searchResults = Environment.Current().SearchModule().Search(searchObject);
            return ok(searchresultview.render(searchResults));
        }

        public ActionResult AutoComplete(String query)
        {
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
}