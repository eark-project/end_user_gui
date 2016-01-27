using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace end_user_gui.Models
{
    [ComplexType]
    public class DateText
    {
        public DateTime? Date { get; set; }
        public String Text { get; set; }
    }
}
