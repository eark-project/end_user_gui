using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace end_user_gui.Models
{
    [ComplexType]
    public class Dissemination
    {
        public Guid UUID = Guid.NewGuid();

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
                return UUID.ToString();
            }
        }
    }
}
