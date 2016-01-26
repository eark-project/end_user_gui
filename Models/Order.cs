using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace end_user_gui.Models
{
    public class Order
    {
        [Key]
        public String OrderUniqueID { get; set; }
        public String OrderTitle { get; set; }

        // Get
        public List<OrderArchiveReference> Archives { get; set; } = new List<OrderArchiveReference>();

        public List<DeliveryMethod> OrderOrigins { get; set; }

        [NotMapped]
        public List<String> EndUserNotes { get; set; }

        [NotMapped]
        public List<String> ArchivistNotes { get; set; }

        public DateTime IssueDate { get; set; }

        public virtual EndUser User { get; set; }

        public DateTime? PlannedDate { get; set; }

        public DateText ExpectedReadyDate { get; set; } = new DateText();

        [NotMapped]
        public Archivist Archivist { get; set; }

        [NotMapped]
        public List<String> InternalNotes { get; set; }

        [NotMapped]
        public List<DeliveryFormat> DeliveryFormats { get; set; }

        /*Accessor methods*/
        public Boolean Add(Archive archive)
        {
            return Add(archive, null);
        }

        public Boolean Add(Archive archive, Dissemination dissemination)
        {
            this.Archives.Add(
                    new OrderArchiveReference()
                    {
                        Archive = archive,
                        Dissemination = dissemination,
                        Status = new OrderStatus()
                        {
                            Status = null,
                            StatusDate = null
                        }
                    }
            );
            return true;
        }

        public Boolean Remove(Archive archive)
        {
            // TODO: LINQ
            foreach (OrderArchiveReference orderArchiveReference in this.Archives)
            {
                if (orderArchiveReference.Archive.ReferenceCode.Equals(archive.ReferenceCode))
                {
                    Archives.Remove(orderArchiveReference);
                    return true;
                }
            }
            return false;
        }
    }
}