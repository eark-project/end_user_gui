using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace end_user_gui.Models.dummy
{
    public class Dissemination : IDissemination
    {
        public DateTime CreatedDate { get; set; }

        public String _DummyDescription;

        public override String ToString()
        {
            return _DummyDescription;
        }

        public String KeyString
        {
            get
            {
                return CreatedDate.ToString();
            }
        }
    }
}