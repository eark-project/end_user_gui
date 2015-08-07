package models;

import java.util.Date;

/**
 * Created by Beemen on 29/07/2015.
 */
public class OrderArchiveReference {
    public IArchive Archive;
    public IDissemination Dissemination;
    public String LevelOfDescription;
    public Date AccessEndDate;
    public OrderStatus Status;
    public AccessRestriction AccessRestriction;
}
