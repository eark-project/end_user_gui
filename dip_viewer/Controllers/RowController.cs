using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dip_viewer.Modules;
using com.databasepreservation.model.structure;
using java.sql;

namespace dip_viewer.Controllers
{
    public class RowController : Controller
    {
        private IDipRepository DipRepository;

        public RowController(IDipRepository repo)
        {
            DipRepository = repo;
        }

        // GET: Row
        public ActionResult Index(string package, string schema, string table, int pageNumber = 1, int maxRows = 20)
        {
            var module = this.DipRepository.getImportModule(package);
            var tableObject = DipRepository.getDatabaseStructure(package)?.getSchemaByName(schema)?.getTables().toArray().OfType<TableStructure>().FirstOrDefault(t => t.getName().Equals(table));
            if (tableObject != null)
            {
                using (var rs = module.getTableRawData(tableObject))
                {
                    int numColumns = tableObject.getColumns().size();

                    // 1-based index
                    var beforeFirstRowIndex = (pageNumber - 1) * maxRows;

                    // Stop at the row before first row to read
                    while (rs.getRow() < beforeFirstRowIndex)
                    {
                        if (!rs.next())
                            break;
                    }

                    if (rs.getRow() == beforeFirstRowIndex)
                    {
                        var rowData = new List<string[]>();

                        while (rowData.Count < maxRows && rs.next())
                        {
                            rowData.Add(Enumerable.Range(1, numColumns).Select(iCol => rs.getString(iCol)).ToArray());
                        }
                        var pl = new PagedList.StaticPagedList<string[]>(rowData, pageNumber, maxRows, (int)tableObject.getRows());
                        var parameters = new IndexParameters()
                        {
                            Package = package,
                            Table = tableObject,
                            RowData = pl
                        };
                        return View(parameters);
                    }
                }
            }
            throw new InvalidOperationException();
        }

        public class IndexParameters
        {
            public string Package;
            public PagedList.IPagedList<string[]> RowData;
            public TableStructure Table;
        }
    }
}