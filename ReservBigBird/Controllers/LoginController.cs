using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReservBigBird;
using ReservBigBird.Models;
using ReservBigBird.Security;
using ReservBigBird.ViewModel;

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
            //if(ModelState.IsValid)
            //{
            //    var result = db.LoginNewTbls.Where(a => a.username.Equals(login.username) && a.pass.Equals(login.pass)).FirstOrDefault();

            //    if (result != null)
            //    {
            //        Session["user"] = result.username;

            //        return RedirectToAction("Index", "TerimaOrder");
            //    }
            //    ViewBag.errorlogin = "Username dan Password yang Anda masukan tidak cocok";
            //    //TempData["MsgNoData"] = "Wrong Username Or Password";
            //    return View();
            //}

            //return View(login);
            AccountModel accountModel = new AccountModel();
            if (string.IsNullOrEmpty(Account.Username) || string.IsNullOrEmpty(AccountViewModel.Account.Password) || accountModel.login(AccountViewModel.Account.Username, AccountViewModel.Account.Password) == null)
            {
                ViewBag.Error = "Please provide your username and password correct!!!";
                return View("Index");
            }
            SimpleSessionPersister.Username = AccountViewModel.Account.Username;
            return View("Welcome");
        }
    }
}