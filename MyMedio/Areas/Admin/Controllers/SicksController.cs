using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace MyMedio.Areas.Admin.Controllers
{
    [Authorize]
    public class SicksController : Controller
    {
        private Mycontext db = new Mycontext();

        // GET: Admin/Sicks
        //public ActionResult Index()
        //{
        //    var sicks = db.Sicks.Include(s => s.SickGroup);
        //    return PartialView(sicks.ToList());
        //}

        public ActionResult Index(int? GrohBimariID)
        {
            var model = GrohBimariID == null ?
                db.Sicks.ToList() :
                db.Sicks.Where(s => s.GrohBimariID == GrohBimariID).ToList();

            return View(model);
        }


        // GET: Admin/Sicks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sick sick = db.Sicks.Find(id);
            if (sick == null)
            {
                return HttpNotFound();
            }
            return PartialView(sick);
        }

        // GET: Admin/Sicks/Create
        public ActionResult Create()
        {
            // برای دراپ دون رضایت نامه 
            var uniqueSicks = db.Sicks
                    .Select(s => new { s.GrohBimariID, s.RezayatName })
                    .GroupBy(s => s.RezayatName)
                    .Select(g => g.FirstOrDefault())
                    .ToList();
            ViewBag.RezayatName = new SelectList(uniqueSicks, "GrohBimariID", "RezayatName");

            //برای دراپ دون وضعیت تاهل
            var uniqueSicks1 = db.Sicks
                    .Select(s => new { s.GrohBimariID, s.Moteahel })
                    .GroupBy(s => s.Moteahel)
                    .Select(g => g.FirstOrDefault())
                    .ToList();
            ViewBag.Moteahel = new SelectList(uniqueSicks1, "GrohBimariID", "Moteahel");

            //برای دراپ دون وضعیت فرزند
            var uniqueSicks2 = db.Sicks
                    .Select(m => new { m.GrohBimariID, m.Farzand })
                    .GroupBy(m => m.Farzand)
                    .Select(g => g.FirstOrDefault())
                    .ToList();

            ViewBag.Farzand = new SelectList(uniqueSicks2, "GrohBimariID", "Farzand");

            //برای دراپ دون گروه بیماری
            ViewBag.GrohBimariID = new SelectList(db.SickGroups, "GrohBimariID", "GroupBimariTitle");
            return PartialView();
        }

        // POST: Admin/Sicks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        // POST: Admin/Sicks/Create
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create([Bind(Include = "BimarID,GrohBimariID,NameBimar,FamilBimar,Codemeli,NamePedar,Moteahel,Farzand,TedadFarzand,RezayatName,ImageNameRezayat")] Sick sick, HttpPostedFileBase imgUp)
        {
            if (ModelState.IsValid)
            {
                // تاریخ جاری به CreateDate اختصاص داده می‌شود
                sick.CreateDate = DateTime.Now;

                if (imgUp != null && imgUp.ContentLength > 0)
                {
                    sick.ImageNameRezayat = Guid.NewGuid() + Path.GetExtension(imgUp.FileName);
                    imgUp.SaveAs(Server.MapPath("/Images/" + sick.ImageNameRezayat));
                }

                // اینجا برای به‌روزرسانی عنوان گروه بیماری
                var sickGroup = db.SickGroups.Find(sick.GrohBimariID);
                if (sickGroup != null)
                {
                    sick.GroupBimariTitle = sickGroup.GroupBimariTitle; // بر اساس ID گروه عنوان را تنظیم کنید
                }

                db.Sicks.Add(sick);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GrohBimariID = new SelectList(db.SickGroups, "GrohBimariID", "GroupBimariTitle", sick.GrohBimariID);
            return PartialView(sick);
        }

        // GET: Admin/Sicks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sick sick = db.Sicks.Find(id);
            if (sick == null)
            {
                return HttpNotFound();
            }

            // برای دراپ دون رضایت نامه 
            var uniqueSicks = db.Sicks
                    .Select(s => new { s.GrohBimariID, s.RezayatName })
                    .GroupBy(s => s.RezayatName)
                    .Select(g => g.FirstOrDefault())
                    .ToList();
            ViewBag.RezayatName = new SelectList(uniqueSicks, "RezayatName", "RezayatName");

            // برای دراپ دون وضعیت تاهل
            var uniqueSicks1 = db.Sicks
                    .Select(m => new { m.GrohBimariID, m.Moteahel })
                    .GroupBy(m => m.Moteahel)
                    .Select(g => g.FirstOrDefault())
                    .ToList();

            ViewBag.Moteahel = new SelectList(uniqueSicks1, "Moteahel", "Moteahel");

            // برای دراپ دون وضعیت فرزند
            var uniqueSicks2 = db.Sicks
                    .Select(m => new { m.GrohBimariID, m.Farzand })
                    .GroupBy(m => m.Farzand)
                    .Select(g => g.FirstOrDefault())
                    .ToList();

            ViewBag.Farzand = new SelectList(uniqueSicks2, "Farzand", "Farzand");

            // برای دراپ دون گروه بیماری
            ViewBag.GrohBimariID = new SelectList(db.SickGroups, "GrohBimariID", "GroupBimariTitle", sick.GrohBimariID);
            return PartialView(sick);
        }

        // POST: Admin/Sicks/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BimarID,GrohBimariID,CreateDate,NameBimar,FamilBimar,Codemeli,NamePedar,Moteahel,Farzand,TedadFarzand,RezayatName,ImageNameRezayat")] Sick sick, HttpPostedFileBase imgUp)
        {
            if (ModelState.IsValid)
            {
                if (imgUp != null && imgUp.ContentLength > 0)
                {
                    sick.ImageNameRezayat = Guid.NewGuid() + Path.GetExtension(imgUp.FileName);
                    imgUp.SaveAs(Server.MapPath("/Images/" + sick.ImageNameRezayat));
                }

                // اینجا برای به‌روزرسانی عنوان گروه بیماری
                var sickGroup = db.SickGroups.Find(sick.GrohBimariID);
                if (sickGroup != null)
                {
                    sick.GroupBimariTitle = sickGroup.GroupBimariTitle; // بر اساس ID گروه عنوان را تنظیم کنید
                }

                db.Entry(sick).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GrohBimariID = new SelectList(db.SickGroups, "GrohBimariID", "GroupBimariTitle", sick.GrohBimariID);
            return PartialView(sick);
        }
        // GET: Admin/Sicks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sick sick = db.Sicks.Find(id);
            if (sick == null)
            {
                return HttpNotFound();
            }
            return PartialView(sick);
        }

        // POST: Admin/Sicks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sick sick = db.Sicks.Find(id);
            db.Sicks.Remove(sick);
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
