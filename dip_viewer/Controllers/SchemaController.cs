using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using com.databasepreservation.modules.sqlServer;
using com.databasepreservation.model.structure;

namespace dip_viewer.Controllers
{
    public class SchemaController : Controller
    {
        Modules.IDipRepository DipRepository;

        public SchemaController(Modules.IDipRepository repo)
        {
            this.DipRepository = repo;
        }
        public ActionResult Index(string package = "123")
        {
            var db = this.DipRepository.getDatabaseStructure(package);

            ViewBag.PackageId = package;
            return View("Index", db.getSchemas().toArray().OfType<SchemaStructure>());
        }
    }


}