package models.dummy;

import models.*;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

/**
 * Created by Beemen on 31/07/2015.
 */
public class DummyOrder implements IOrder {

    String _OrderUniqueID;
    @Override
    public String OrderUniqueID() {
        return _OrderUniqueID;
    }

    @Override
    public void OrderUniqueID(String value) {
        _OrderUniqueID = value;
    }

    @Override
    public String OrderTitle() {
        return null;
    }

    @Override
    public void OrderTitle(String value) {

    }

    private final List<OrderArchiveReference> _Archives = new ArrayList<>();
    @Override
    public List<OrderArchiveReference> Archives() {
        return _Archives;
    }

    @Override
    public List<DeliveryMethod> OrderOrigins() {
        return null;
    }

    @Override
    public List<String> EndUserNotes() {
        return null;
    }

    @Override
    public List<String> ArchivistNotes() {
        return null;
    }

    private Date _IssueDate;
    @Override
    public Date IssueDate() {
        return _IssueDate;
    }

    @Override
    public void IssueDate(Date value) {
        _IssueDate = value;
    }

    IEndUser _User;
    @Override
    public IEndUser User() {
        return _User;
    }

    @Override
    public void User(IEndUser value) {
        _User = value;
    }

    @Override
    public Date PlannedDate() {
        return null;
    }

    @Override
    public void PlannedDate(Date value) {

    }

    @Override
    public DateText ExpectedReadyDate() {
        return null;
    }

    @Override
    public void ExpectedReadyDate(DateText value) {

    }

    @Override
    public IArchivist Archivist() {
        return null;
    }

    @Override
    public void Archivist(IArchivist value) {

    }

    @Override
    public List<String> InternalNotes() {
        return null;
    }

    @Override
    public List<DeliveryFormat> DeliveryFormats() {
        return null;
    }

    @Override
    public Boolean Add(IArchive archive) {
        return Add(archive, null);
    }

    @Override
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

    @Override
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
