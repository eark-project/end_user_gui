using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace end_user_gui.Controllers
{
    public class OrderController : Controller
    {
        public ActionResult View()
        {
            return ok(cartview_body.render(Environment.Current().Session().CurrentOrder()));
        }

        public ActionResult Count()
        {
            int c = Environment.Current().Session().CurrentOrder().Archives().size();
            String s = "";
            if (c > 0)
                s = "(" + new Integer(c).toString() + ")";

            return ok(s);
        }

        public ActionResult Empty()
        {
            Environment.Current().Session().CurrentOrder().Archives().clear();
            return ok();
        }

        public ActionResult OpenAddDialog(String key)
        {
            IArchive archive = Environment.Current().SearchModule().Lookup(key);
            List<IDissemination> ret = Environment.Current().ArchiveRepository().GetDIPs(archive);
            return ok(addtocartmodal_body.render(archive, ret));
        }

        public ActionResult Add(String key, String disKey, String commnets)
        {
            IArchive archive = Environment.Current().SearchModule().Lookup(key);
            IDissemination dissemination = null;
            if (disKey != null && disKey.length() > 0)
            {
                dissemination = Environment.Current().ArchiveRepository().LookupDIP(disKey);
            }
            Environment.Current().Session().CurrentOrder().Add(archive, dissemination);
            return ok();
        }

        public ActionResult Remove(String key)
        {
            IArchive archive = Environment.Current().SearchModule().Lookup(key);
            Environment.Current().Session().CurrentOrder().Remove(archive);
            return ok();
        }

        public ActionResult Submit()
        {
            StandardReturn ret = Environment.Current().OrderModule().SubmitOrder(
                    Environment.Current().Session().CurrentOrder(),
                    Environment.Current().Session().User()
            );
            if (ret.Succeeded)
            {
                Environment.Current().Session().NewOrder();
            }
            return ok(ret.toString());
        }
    }
}