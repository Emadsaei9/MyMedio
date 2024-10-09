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
    public class DocumentsController : Controller
    {
        private Mycontext db = new Mycontext();

        //// GET: Admin/Documents
        //public ActionResult Index()
        //{
        //    var documents = db.Documents.Include(d => d.Sick);
        //    return View(documents.ToList());
        //}

        public ActionResult Index(int? BimarID)
        {
            var model = BimarID == null ?
                db.Documents.ToList() :
                db.Documents.Where(s => s.BimarID == BimarID).ToList();

            return View(model);
        }



        // GET: Admin/Documents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Documents documents = db.Documents.Find(id);
            if (documents == null)
            {
                return HttpNotFound();
            }
            return PartialView(documents);
        }

        // GET: Admin/Documents/Create
        public ActionResult Create()
        {
            ViewBag.BimarID = new SelectList(db.Sicks, "BimarID", "NameBimar");
            return PartialView();
        }

        // POST: Admin/Documents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TazrighID,BimarID,HajmeTazrigh,GelzatTazrigh,NaghsJenetik,NoeTazrigh,Comision,ElatTzrigh,SabegheGhabli,SabegheDarman,SabegheFamily,SharhHal")] Documents documents)
        {
            if (ModelState.IsValid)
            {
                db.Documents.Add(documents);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BimarID = new SelectList(db.Sicks, "BimarID", "NameBimar", documents.BimarID);
            return PartialView(documents);
        }

        // GET: Admin/Documents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Documents documents = db.Documents.Find(id);
            if (documents == null)
            {
                return HttpNotFound();
            }
            ViewBag.BimarID = new SelectList(db.Sicks, "BimarID", "NameBimar", documents.BimarID);
            return PartialView(documents);
        }

        // POST: Admin/Documents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TazrighID,BimarID,HajmeTazrigh,GelzatTazrigh,NaghsJenetik,NoeTazrigh,Comision,ElatTzrigh,SabegheGhabli,SabegheDarman,SabegheFamily,SharhHal")] Documents documents)
        {
            if (ModelState.IsValid)
            {
                db.Entry(documents).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BimarID = new SelectList(db.Sicks, "BimarID", "NameBimar", documents.BimarID);
            return PartialView(documents);
        }

        // GET: Admin/Documents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Documents documents = db.Documents.Find(id);
            if (documents == null)
            {
                return HttpNotFound();
            }
            return PartialView(documents);
        }

        // POST: Admin/Documents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Documents documents = db.Documents.Find(id);
            db.Documents.Remove(documents);
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
