using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace end_user_gui.Controllers
{
    public class UserController : Controller
    {
        public ActionResult ProfileSummary()
        {
            return View("profile", end_user_gui.Modules.Environment.Current());
        }
    }
}