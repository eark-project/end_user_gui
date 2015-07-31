package models.dummy;

import models.IArchive;

/**
 * Created by Beemen on 30/07/2015.
 */
public class Archive implements IArchive {

    private String _ReferenceCode;
    @Override
    public String ReferenceCode() {
        return _ReferenceCode;
    }

    @Override
    public void ReferenceCode(String value) {
        this._ReferenceCode = value;
    }

    private String _AirUrl;
    @Override
    public String AipUri() {
        return _AirUrl;
    }

    @Override
    public void AipUri(String value) {
        _AirUrl = value;
    }
}
