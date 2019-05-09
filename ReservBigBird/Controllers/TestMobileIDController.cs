using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ReservBigBird.Controllers
{
    public class TestMobileIDController : Controller
    {
        // GET: TestMobileID
        public ActionResult Index()
        {
            var AA = Request.Browser.IsMobileDevice;
            var BB = Request.Browser.

            return View();
        }
    }
}