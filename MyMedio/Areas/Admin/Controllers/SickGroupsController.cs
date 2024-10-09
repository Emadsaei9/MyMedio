using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace MyMedio.Areas.Admin.Controllers
{
    [Authorize]
    public class SickGroupsController : Controller
    {
        private Mycontext db = new Mycontext();

        // GET: Admin/SickGroups
        public ActionResult Index()
        {
            return View(db.SickGroups.ToList());
        }

        // GET: Admin/SickGroups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SickGroup sickGroup = db.SickGroups.Find(id);
            if (sickGroup == null)
            {
                return HttpNotFound();
            }
            return PartialView(sickGroup);
        }

        // GET: Admin/SickGroups/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: Admin/SickGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GrohBimariID,GroupBimariTitle")] SickGroup sickGroup)
        {
            if (ModelState.IsValid)
            {
                db.SickGroups.Add(sickGroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sickGroup);
        }

        // GET: Admin/SickGroups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SickGroup sickGroup = db.SickGroups.Find(id);
            if (sickGroup == null)
            {
                return HttpNotFound();
            }
            return PartialView(sickGroup);
        }

        // POST: Admin/SickGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GrohBimariID,GroupBimariTitle")] SickGroup sickGroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sickGroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return PartialView(sickGroup);
        }

        // GET: Admin/SickGroups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SickGroup sickGroup = db.SickGroups.Find(id);
            if (sickGroup == null)
            {
                return HttpNotFound();
            }
            return PartialView(sickGroup);
        }

        // POST: Admin/SickGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SickGroup sickGroup = db.SickGroups.Find(id);
            db.SickGroups.Remove(sickGroup);
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
