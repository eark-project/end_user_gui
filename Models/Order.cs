using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace end_user_gui.Models
{
    public class Order
    {
        public String OrderUniqueID { get; set; }
        public String OrderTitle { get; set; }

        // Get
        public List<OrderArchiveReference> Archives { get; set; } = new List<OrderArchiveReference>();
        public List<DeliveryMethod> OrderOrigins { get; set; }
        public List<String> EndUserNotes { get; set; }
        public List<String> ArchivistNotes { get; set; }
        public DateTime IssueDate { get; set; }
        public EndUser User { get; set; }
        public DateTime PlannedDate { get; set; }
        public DateText ExpectedReadyDate { get; set; }
        public Archivist Archivist { get; set; }
        public List<String> InternalNotes { get; set; }
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
                            Status = "",
                            StatusDate = new DateTime(),
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