using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace end_user_gui.Models.dummy
{
public class DummyOrder : IOrder {

    String _OrderUniqueID;
    public String OrderUniqueID() {
        return _OrderUniqueID;
    }

    public void OrderUniqueID(String value) {
        _OrderUniqueID = value;
    }

    public String OrderTitle() {
        return null;
    }

    public void OrderTitle(String value) {

    }

    private final List<OrderArchiveReference> _Archives = new ArrayList<>();
    public List<OrderArchiveReference> Archives() {
        return _Archives;
    }

    public List<DeliveryMethod> OrderOrigins() {
        return null;
    }

    public List<String> EndUserNotes() {
        return null;
    }

    public List<String> ArchivistNotes() {
        return null;
    }

    private Date _IssueDate;
    public Date IssueDate() {
        return _IssueDate;
    }

    public void IssueDate(Date value) {
        _IssueDate = value;
    }

    IEndUser _User;
    public IEndUser User() {
        return _User;
    }

    public void User(IEndUser value) {
        _User = value;
    }

    public Date PlannedDate() {
        return null;
    }

    public void PlannedDate(Date value) {

    }

    public DateText ExpectedReadyDate() {
        return null;
    }

    public void ExpectedReadyDate(DateText value) {

    }

    public IArchivist Archivist() {
        return null;
    }

    public void Archivist(IArchivist value) {

    }

    public List<String> InternalNotes() {
        return null;
    }

    public List<DeliveryFormat> DeliveryFormats() {
        return null;
    }

    public Boolean Add(IArchive archive) {
        return Add(archive, null);
    }

    public Boolean Add(IArchive archive, IDissemination dissemination) {
        this.Archives().add(
                new OrderArchiveReference(){{
                    Archive = archive;
                    Dissemination = dissemination;
                    Status =new OrderStatus(){{
                        Status = "";
                        StatusDate = new Date();
                    }};
                }}
        );
        return true;
    }

    public Boolean Remove(IArchive archive) {
        for (OrderArchiveReference orderArchiveReference:this.Archives()){
            if(orderArchiveReference.Archive.ReferenceCode().equals(archive.ReferenceCode())){
                Archives().remove(orderArchiveReference);
                return true;
            }
        }
        return false;
    }
}
}