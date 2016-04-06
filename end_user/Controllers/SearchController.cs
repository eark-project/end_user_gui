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
                var searchin = HttpContext.Request["searchin"];
                ArchiveSearchObject searchObject = new ArchiveSearchObject()
                {
                    name = HttpContext.Request["name"],
                    Description = HttpContext.Request["description"],
                    Metadata = Convert.ToBoolean(HttpContext.Request["meta"]),
                    SearchInTitle = searchin.Equals("both") || searchin.Equals("title"),
                    SearchInDescription = searchin.Equals("both") || searchin.Equals("description"),
                    StartIndex = pageNumber - 1
                };
                searchObject.StartIndex *= searchObject.MaxResults;
                mod.ISearchModule searchModule = searchObject.Metadata ?
                    mod.Environment.Current().MetadataSearchModule() as mod.ISearchModule
                    : mod.Environment.Current().ContentSearchModule() as mod.ISearchModule;
                var searchResults = searchModule.Search(searchObject);
                var searchResultCount = searchModule.SearchCount(searchObject);

                var list = new StaticPagedList<Archive>(searchResults, pageNumber, searchObject.MaxResults, searchResultCount);

                ViewBag.CurrentFilter = searchObject.name;
                return View("searchresultview", list);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public PartialViewResult PackageFiles(string referenceCode)
        {
            Archive ret = mod.Environment.Current().ContentSearchModule().Lookup(referenceCode);
            return PartialView("PackageFiles", ret);
        }

        public JsonResult AutoComplete(String query)
        {
            ArchiveSearchObject searchObject = new ArchiveSearchObject();
            searchObject.name = query;

            List<Archive> searchResults = mod.Environment.Current().ContentSearchModule().Search(searchObject);
            String[] ret = searchResults.Select(sr => sr.ReferenceCode).ToArray();

            // TODO: Fill result
            return new JsonResult();
        }
    }
}