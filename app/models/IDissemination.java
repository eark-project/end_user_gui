package models;

import java.util.Date;

/**
 * Created by Beemen on 29/07/2015.
 */
public interface IDissemination {
    Date CreatedDate();
    void CreatedDate(Date value);

    String ToString();
    String KeyString();
}
