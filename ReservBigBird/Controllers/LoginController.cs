using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReservBigBird;

namespace ReservBigBird.Controllers
{
    public class LoginController : Controller
    {
        private devbigbirdEntities db = new devbigbirdEntities();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginNewTbl login)
        {
            if(ModelState.IsValid)
            {
                var result = db.LoginNewTbls.Where(a => a.username.Equals(login.username) && a.pass.Equals(login.pass)).FirstOrDefault();

                if (result != null)
                {
                    Session["user"] = result.username;
                    
                    return RedirectToAction("Index", "TerimaOrder");
                }
                ViewBag.errorlogin = "Username dan Password yang Anda masukan tidak cocok";
                //TempData["MsgNoData"] = "Wrong Username Or Password";
                return View();
            }

            return View(login);
            
        }
    }
}