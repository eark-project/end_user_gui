using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace end_user_gui.Models
{

    public class StandardReturn
    {
        public bool Succeeded { get; set; }
        public int Code { get; set; }
        public String Text { get; set; }

        public static StandardReturn OK()
        {
            return new StandardReturn()
            {
                Succeeded = true,
                Code = 200,
                Text = "",
            };
        }

        public static StandardReturn InvalidInput(String text)
        {
            return new StandardReturn()
            {
                Succeeded = false,
                Code = 400,
                Text = text,
            };
        }

        public String toString()
        {
            return String.Format("{0} : {1} {2}", Succeeded, Code, Text);
        }
    }
}