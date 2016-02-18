using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using com.databasepreservation.model.structure;
using com.databasepreservation.model.modules;

namespace dip_viewer.Modules
{
    public interface IDipRepository
    {
        DatabaseImportModule getImportModule(string identifier);
        DatabaseStructure getDatabaseStructure(string identifier);
    }
}