using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace end_user_gui.Models
{
    public interface IOrder
    {
        String OrderUniqueID();
        void OrderUniqueID(String value);

        String OrderTitle();
        void OrderTitle(String value);

        // Get
        public List<OrderArchiveReference> Archives { get; }
        List<DeliveryMethod> OrderOrigins { get; }
        List<String> EndUserNotes { get; }
        List<String> ArchivistNotes { get; }
        DateTime IssueDate { get; set; }
        IEndUser User { get; set; }
        DateTime PlannedDate { get; set; }
        DateText ExpectedReadyDate { get; set; }
        IArchivist Archivist { get; set; }
        List<String> InternalNotes { get; }
        List<DeliveryFormat> DeliveryFormats { get; }

        /*Accessor methods*/
        Boolean Add(IArchive archive);
        Boolean Add(IArchive archive, IDissemination dissemination);
        Boolean Remove(IArchive archive);
    }
}