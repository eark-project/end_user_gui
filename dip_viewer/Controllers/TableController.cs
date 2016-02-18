using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using com.databasepreservation.model.structure;

using System.Web.Mvc;

namespace dip_viewer.Controllers
{
    public class TableController : Controller
    {
        Modules.IDipRepository DipRepository;

        public TableController(Modules.IDipRepository repo)
        {
            this.DipRepository = repo;
        }

        public ActionResult Index(string package = "123", string schema = null)
        {
            var db = DipRepository.getDatabaseStructure(package);
            IEnumerable<SchemaStructure> schemas = string.IsNullOrEmpty(schema) ?
                db.getSchemas().toArray().OfType<SchemaStructure>()
                : new SchemaStructure[] { db.getSchemaByName(schema) }.Where(s => s != null);

            var tables = schemas.SelectMany(s => s.getTables().toArray().OfType<TableStructure>());

            ViewBag.Package = package;

            return View(tables);
        }
    }
}