using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReservBigBird.Controllers
{
    public class TerimaOrderController : Controller
    {
        // GET: TerimaOrder
        public ActionResult Index()
        {
            if(Session["user"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}