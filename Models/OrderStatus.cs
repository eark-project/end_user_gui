using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace end_user_gui.Models
{
    [ComplexType]
    public class OrderStatus
    {
        public String Status { get; set; }
        public DateTime StatusDate { get; set; }
    }
}