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
        public List<OrderArchiveReference> Archives();

        List<DeliveryMethod> OrderOrigins();

        List<String> EndUserNotes();

        List<String> ArchivistNotes();

        Date IssueDate();
        void IssueDate(Date value);

        IEndUser User();
        void User(IEndUser value);

        Date PlannedDate();
        void PlannedDate(Date value);

        DateText ExpectedReadyDate();
        void ExpectedReadyDate(DateText value);

        IArchivist Archivist();
        void Archivist(IArchivist value);

        List<String> InternalNotes();

        List<DeliveryFormat> DeliveryFormats();

        /*Accessor methods*/
        Boolean Add(IArchive archive);
        Boolean Add(IArchive archive, IDissemination dissemination);
        Boolean Remove(IArchive archive);
    }
}