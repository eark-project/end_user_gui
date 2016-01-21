using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace end_user_gui.Models
{
    public interface IOrder
    {
        String OrderUniqueID { get; set; }
        String OrderTitle { get; set; }

        // Get
        List<OrderArchiveReference> Archives { get; }
        List<DeliveryMethod> OrderOrigins { get; }
        List<String> EndUserNotes { get; }
        List<String> ArchivistNotes { get; }
        DateTime IssueDate { get; set; }
        EndUser User { get; set; }
        DateTime PlannedDate { get; set; }
        DateText ExpectedReadyDate { get; set; }
        Archivist Archivist { get; set; }
        List<String> InternalNotes { get; }
        List<DeliveryFormat> DeliveryFormats { get; }

        /*Accessor methods*/
        Boolean Add(Archive archive);
        Boolean Add(Archive archive, Dissemination dissemination);
        Boolean Remove(Archive archive);
    }
}