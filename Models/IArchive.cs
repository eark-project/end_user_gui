using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace end_user_gui.Models
{
    public interface IArchive
    {
        String ReferenceCode();
        void ReferenceCode(String value);

        String AipUri();
        void AipUri(String value);
    }
}