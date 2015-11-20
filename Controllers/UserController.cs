using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

/**
* Created by Beemen on 03/08/2015.
*/
namespace end_user_gui.Controllers
{
    public class UserController : Controller
    {
        public Result ProfileSummary()
        {
            return ok(profile.render(Environment.Current()));
        }
    }
}