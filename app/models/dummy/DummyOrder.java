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

    @Override
    public Date IssueDate() {
        return null;
    }

    @Override
    public void IssueDate(Date value) {

    }

    @Override
    public IEndUser User() {
        return null;
    }

    @Override
    public void User(IEndUser value) {

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
}
