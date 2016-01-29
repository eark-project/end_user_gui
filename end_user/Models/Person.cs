using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace end_user_gui.Models
{
    public class Person
    {
        public virtual string Name { get; set; }

        [Key]
        public string UniqueId { get; set; }
    }
}