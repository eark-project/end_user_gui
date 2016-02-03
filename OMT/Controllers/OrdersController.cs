using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using end_user_gui.Models;

namespace OMT.Controllers
{
    public class OrdersController : Controller
    {
        private OrderContext db = new OrderContext();

        // GET: Orders
        public ActionResult Index()
        {
            using (var context = new OrderContext())
            {
                var ss = context.Archivists
                    .Select(a => new SelectListItem() { Text = a.Name, Value = a.UniqueId })
                    .ToList();
                ViewBag.Archivists = ss;
            }
            return View(db.Orders.Include(o => o.Archivist).ToList());
        }

        // GET: Orders/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderUniqueID,OrderTitle,IssueDate,PlannedDate,ExpectedReadyDate")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(order);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderUniqueID,OrderTitle,IssueDate,PlannedDate,ExpectedReadyDate")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(order);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        public PartialViewResult SelectArchivist(string orderId)
        {
            using (var context = new OrderContext())
            {
                ViewBag.Archivists = context.Archivists
                    .Select(a => new SelectListItem() { Text = a.Name, Value = a.UniqueId })
                    .ToList();
                var order = context.Orders.Where(o => o.OrderUniqueID == orderId).Include(o => o.Archivist).SingleOrDefault();
                ViewData["elementId"] = "selArch_" + order.OrderUniqueID;

                return PartialView("AssignedToSelect", order);
            }
        }

        public PartialViewResult SetArchivist(string orderId, bool set, string archivistId)
        {
            using (var context = new OrderContext())
            {
                var order = context.Orders.Where(o => o.OrderUniqueID == orderId).Include(o => o.Archivist).SingleOrDefault();
                if (set)
                {
                    order.Archivist = context.Archivists.Where(a => a.UniqueId == archivistId).FirstOrDefault();
                    context.SaveChanges();
                }

                ViewData["elementId"] = "selArch_" + order.OrderUniqueID;

                return PartialView("AssignedTo", order);
            }
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


    }
}
