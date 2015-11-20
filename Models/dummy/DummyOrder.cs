using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace end_user_gui.Models.dummy
{
    public class DummyOrder : IOrder
    {
        public String OrderUniqueID { get; set; }
        public String OrderTitle { get; set; }
        public readonly List<OrderArchiveReference> Archives = new List<OrderArchiveReference>();
        public List<DeliveryMethod> OrderOrigins = new List<DeliveryMethod>();
        public List<String> EndUserNotes = new List<string>();
        public List<String> ArchivistNotes = new List<string>();
        public DateTime IssueDate { get; set; }
        public IEndUser User { get; set; }
        public DateTime PlannedDate { get; set; }
        public DateText ExpectedReadyDate { get; set; }
        public IArchivist Archivist { get; set; }
        public readonly List<String> InternalNotes = new List<string>();
        public readonly List<DeliveryFormat> DeliveryFormats = new List<DeliveryFormat>();

        public Boolean Add(IArchive archive)
        {
            return Add(archive, null);
        }

        public Boolean Add(IArchive archive, IDissemination dissemination)
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

        public Boolean Remove(IArchive archive)
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