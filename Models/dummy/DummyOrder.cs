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

        private List<OrderArchiveReference> _Archives = new List<OrderArchiveReference>();
        public List<OrderArchiveReference> Archives { get { return _Archives; } }

        private List<DeliveryMethod> _OrderOrigins = new List<DeliveryMethod>();
        public List<DeliveryMethod> OrderOrigins { get { return _OrderOrigins; } }

        private List<String> _EndUserNotes = new List<string>();
        public List<String> EndUserNotes { get { return _EndUserNotes; } }

        private List<String> _ArchivistNotes = new List<string>();
        public List<String> ArchivistNotes { get { return _ArchivistNotes; } }

        public DateTime IssueDate { get; set; }
        public EndUser User { get; set; }
        public DateTime PlannedDate { get; set; }
        public DateText ExpectedReadyDate { get; set; }
        public Archivist Archivist { get; set; }

        private List<String> _InternalNotes = new List<string>();
        public List<String> InternalNotes { get { return _InternalNotes; } }

        private List<DeliveryFormat> _DeliveryFormats = new List<DeliveryFormat>();
        public List<DeliveryFormat> DeliveryFormats { get { return _DeliveryFormats; } }

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