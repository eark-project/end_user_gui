package models.dummy;

import models.IArchive;
import models.IDissemination;

import java.util.Date;

/**
 * Created by Beemen on 06/08/2015.
 */
public class Dissemination implements IDissemination{

    Date _CreatedDate;
    @Override
    public Date CreatedDate() {
        return _CreatedDate;
    }

    @Override
    public void CreatedDate(Date value) {
        _CreatedDate = value;
    }

    public String _DummyDescription;
    @Override
    public String ToString() {
        return _DummyDescription;
    }
}
