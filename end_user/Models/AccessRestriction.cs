using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/**
 * Created by Beemen on 29/07/2015.
 */
namespace end_user_gui.Models
{
    [ComplexType]
    public class AccessRestriction
    {
        public int Code { get; set; }
        public String Text { get; set; }
    }
}