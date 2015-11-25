using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace end_user_gui.Modules
{
    public class ArchiveRepository:IArchiveRepository
    {
        public List<Models.IDissemination> GetDIPs(Models.IArchive archive)
        {
            return new List<Models.IDissemination>();
        }

        public Models.IDissemination LookupDIP(string keyString)
        {
            return null;
        }

        public Models.IArchive Load(string referenceCode)
        {
            throw new NotImplementedException();
        }

        public Models.IArchiveFile LoadFile(string referenceCode, string path)
        {
            /*
             * http://earkdev.ait.ac.at:12060/repository/table/eark1/record/USER.3f64230c-0784-4291-a091-9e9bd6efb440%2FMARS%5C.001%5C.tar/field/n$content/data?ns.n=org.eu.eark
             * http://earkdev.ait.ac.at:12060/repository/table/eark1/record/USER.3f64230c-0784-4291-a091-9e9bd6efb440%2FMARS%5C.001%5C.xml/field/n$content/data?ns.n=org.eu.eark
             * 
             * http://earkdev.ait.ac.at:12060/repository/table/eark1/record/USER.3f64230c-0784-4291-a091-9e9bd6efb440%2FMARS%5C.001%5C.tar/field/n$content/data?ns.n=org.eu.eark
             * http://earkdev.ait.ac.at:12060/repository/table/eark1/record/USER.3f64230c-0784-4291-a091-9e9bd6efb440%2Frepresentations%2Frep-001%2Fschemas%2Fxlink%5C.xsd/field/n$content/data?ns.n=org.eu.eark
             * http://earkdev.ait.ac.at:12060/repository/table/eark1/record/USER.3f64230c-0784-4291-a091-9e9bd6efb440%2Fsubmission%2Frepresentations%2Frep-001%2Fdata%2FMars%5C.odt/field/n$content/data?ns.n=org.eu.eark
             * http://earkdev.ait.ac.at:12060/repository/table/eark1/record/USER.3f64230c-0784-4291-a091-9e9bd6efb440%2Fsubmission%2Frepresentations%2Frep-001%2Fmetadata%2Fpreservation%2Fpremis%5C.xml/field/n$content/data?ns.n=org.eu.eark
             */
            var url = string.Format("{0}{1}{2}{3}",
                BaseUrl,
                referenceCode,
                path,
                Suffix
                );
            return null;
        }

        public static readonly string BaseUrl = "http://earkdev.ait.ac.at:12060/repository/table/eark1/record";
        public static readonly string Suffix = "/field/n$content/data?ns.n=org.eu.eark";
    }
}