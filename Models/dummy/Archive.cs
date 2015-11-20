using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace end_user_gui.Models.dummy
{
    public class Archive : IArchive
    {
        private String _ReferenceCode;

        public String ReferenceCode()
        {
            return _ReferenceCode;
        }

        public void ReferenceCode(String value)
        {
            this._ReferenceCode = value;
        }

        private String _AirUrl;
        public String AipUri()
        {
            return _AirUrl;
        }

        public void AipUri(String value)
        {
            _AirUrl = value;
        }
    }
}
