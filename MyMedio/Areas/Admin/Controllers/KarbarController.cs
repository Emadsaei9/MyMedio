using DataLayer;
using MyMedio.Models.Karbar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMedio.Areas.Admin.Controllers
{
    public class KarbarController : Controller
    {
        private Mycontext db = new Mycontext();
        // GET: Admin/Karbar
        public ActionResult Index()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        public ActionResult Login(Karbar user)
        {
            if (ModelState.IsValid)
            {
                var existingUser = db.Karbars
                    .FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);

                if (existingUser != null)
                {
                    // ورود موفقیت آمیز؛ به صفحه SickGroups بروید
                    return RedirectToAction("Index", "SickGroups");
                }
                else
                {
                    ModelState.AddModelError("", "نام کاربری یا رمز عبور نادرست است.");
                }
            }
            return View("Index");
        }
    }
}