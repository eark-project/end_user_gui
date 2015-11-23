using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using end_user_gui.Models;
using mod = end_user_gui.Modules;

namespace end_user_gui.Controllers
{
    public class OrderController : Controller
    {
        public ActionResult View()
        {
            return View("cartview_body", end_user_gui.Modules.Environment.Current().Session().CurrentOrder);
        }

        public string Count()
        {
            int c = mod.Environment.Current().Session().CurrentOrder.Archives.Count;
            String s = "";
            if (c > 0)
                s = "(" + c + ")";
            return s;
        }

        public ActionResult Empty()
        {
            mod.Environment.Current().Session().CurrentOrder.Archives.Clear();
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        public ActionResult OpenAddDialog(String key)
        {
            IArchive archive = mod.Environment.Current().SearchModule().Lookup(key);
            List<IDissemination> ret = mod.Environment.Current().ArchiveRepository().GetDIPs(archive);
            return View("addtocartmodal_body", new Tuple<IArchive, List<IDissemination>>(archive, ret));
        }

        public ActionResult Add(String key, String disKey, String commnets)
        {
            IArchive archive = mod.Environment.Current().SearchModule().Lookup(key);
            IDissemination dissemination = null;
            if (!string.IsNullOrEmpty(disKey))
            {
                dissemination = mod.Environment.Current().ArchiveRepository().LookupDIP(disKey);
            }
            mod.Environment.Current().Session().CurrentOrder.Add(archive, dissemination);
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        public ActionResult Remove(String key)
        {
            IArchive archive = mod.Environment.Current().SearchModule().Lookup(key);
            mod.Environment.Current().Session().CurrentOrder.Remove(archive);
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        public string Submit()
        {
            StandardReturn ret = mod.Environment.Current().OrderModule().SubmitOrder(
                    mod.Environment.Current().Session().CurrentOrder,
                    mod.Environment.Current().Session().User
            );
            if (ret.Succeeded)
            {
                mod.Environment.Current().Session().NewOrder();
            }
            return ret.toString();
        }
    }
}