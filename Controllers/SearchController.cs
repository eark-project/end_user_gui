using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using end_user_gui.Models;

namespace end_user_gui.Controllers
{
    public class SearchController : Controller
    {
        public ActionResult Search()
        {
            // TODO: Replace with a Form object
            ArchiveSearchObject searchObject = new ArchiveSearchObject() { name = HttpContext.Request["name"] };
            List<IArchive> searchResults = end_user_gui.Modules.Environment.Current().SearchModule().Search(searchObject);
            return View("searchresultview", searchResults);
        }

        public JsonResult AutoComplete(String query)
        {
            ArchiveSearchObject searchObject = new ArchiveSearchObject();
            searchObject.name = query;

            List<IArchive> searchResults = end_user_gui.Modules.Environment.Current().SearchModule().Search(searchObject);
            String[] ret = searchResults.Select(sr => sr.ReferenceCode).ToArray();

            // TODO: Fill result
            return new JsonResult();
        }
    }
}