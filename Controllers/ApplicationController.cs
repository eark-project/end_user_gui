using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace end_user_gui.Controllers
{
    public class Application : Controller
    {
        public static ActionResult Index()
        {
            return ok(index.render("Your new application is ready."));
        }
    }
}