using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace end_user_gui.Models
{
    public class OrderArchiveReference
    {
        [Key]
        public int Id { get; set; }
        public Archive Archive { get; set; }        
        public Dissemination Dissemination { get; set; }
        public String LevelOfDescription { get; set; }
        public DateTime AccessEndDate { get; set; }
        public OrderStatus Status { get; set; }        
        public AccessRestriction AccessRestriction { get; set; }
    }
}