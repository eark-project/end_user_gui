using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using com.databasepreservation.model.structure;
using com.databasepreservation.model.modules;
using java.sql;

namespace dip_viewer.Modules
{
    public class DummyDipRepository : IDipRepository
    {
        static Dictionary<string, DatabaseStructure> _Map = new Dictionary<string, DatabaseStructure>();
        static Dictionary<string, DatabaseImportModule> _ModuleMap = new Dictionary<string, DatabaseImportModule>();

        public DatabaseImportModule getImportModule(string identifier)
        {
            if (!_ModuleMap.ContainsKey(identifier))
            {
                var importModule = new com.databasepreservation.modules.sqlServer.@in.SQLServerJDBCImportModule("BEEMENLAPTOP\\SQLEXPRESS", "PART", "cpr", "cpr", false, false);
                _ModuleMap[identifier] = importModule;
            }
            return _ModuleMap[identifier];
        }

        public DatabaseStructure getDatabaseStructure(string identifier)
        {
            if (!_Map.ContainsKey(identifier))
            {
                var importModule = getImportModule(identifier);

                _Map[identifier] = importModule.getDatabaseStructure();
            }
            return _Map[identifier];
        }
    }

    public static class DatabaseImportModuleExtensions
    {
        public static DatabaseStructure getDatabaseStructure(this DatabaseImportModule module)
        {
            return (module as com.databasepreservation.modules.jdbc.@in.JDBCImportModule).getDatabaseStructure2();
        }

        public static ResultSet getTableRawData(this DatabaseImportModule module, TableStructure table)
        {
            return (module as com.databasepreservation.modules.jdbc.@in.JDBCImportModule).getTableRawData2(table);
        }
    }
}