using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace end_user_gui.Models
{
    public class Person
    {
        public String Name { get; set; }

        [Key]
        public String UniqueId { get; set; }
    }
}