using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using end_user_gui.Models;
using mod = end_user_gui.Modules;
using PagedList;

namespace end_user_gui.Controllers
{
    public class SearchController : Controller
    {
        public ActionResult Search()
        {
            try
            {
                var pageNumber = int.Parse(HttpContext.Request["page"] ?? "1");

                ArchiveSearchObject searchObject = new ArchiveSearchObject()
                {
                    name = HttpContext.Request["name"],
                    StartIndex = pageNumber - 1
                };
                searchObject.StartIndex *= searchObject.MaxResults;

                List<IArchive> searchResults = mod.Environment.Current().SearchModule().Search(searchObject);

                var list = new StaticPagedList<IArchive>(searchResults, pageNumber, searchObject.MaxResults, 1000);

                ViewBag.CurrentFilter = searchObject.name;
                return View("searchresultview", list);
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public JsonResult AutoComplete(String query)
        {
            ArchiveSearchObject searchObject = new ArchiveSearchObject();
            searchObject.name = query;

            List<IArchive> searchResults = mod.Environment.Current().SearchModule().Search(searchObject);
            String[] ret = searchResults.Select(sr => sr.ReferenceCode).ToArray();

            // TODO: Fill result
            return new JsonResult();
        }
    }
}