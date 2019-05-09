using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReservBigBird.Controllers
{
    public class ServerSideDTController : Controller
    {
        private devbigbirdEntities db = new devbigbirdEntities();

        // GET: ServerSideDT
        public ActionResult Index()
        {
            return View();
        }
    }
}