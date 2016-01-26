using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace end_user_gui.Models
{
    public class OrderArchiveReference
    {
        [Key]
        public int Id { get; set; }
        public Archive Archive { get; set; }
        [NotMapped]
        public Dissemination Dissemination { get; set; }
        public string LevelOfDescription { get; set; }
        public DateTime? AccessEndDate { get; set; }
        public OrderStatus Status { get; set; } = new OrderStatus();
        public AccessRestriction AccessRestriction { get; set; } = new AccessRestriction();
    }
}