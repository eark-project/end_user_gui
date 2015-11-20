using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace end_user_gui.Models.dummy
{
public class Dissemination implements IDissemination{

    Date _CreatedDate;
    public Date CreatedDate() {
        return _CreatedDate;
    }

    public void CreatedDate(Date value) {
        _CreatedDate = value;
    }

    public String _DummyDescription;
    public String ToString() {
        return _DummyDescription;
    }

    public String KeyString() {
        return _CreatedDate.toString();
    }
}
}