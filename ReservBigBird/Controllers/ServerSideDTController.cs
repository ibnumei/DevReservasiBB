using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReservBigBird.Controllers
{
    public class ServerSideDTController : Controller
    {
        private devbigbirdEntities1 db = new devbigbirdEntities1();

        // GET: ServerSideDT
        public ActionResult Index()
        {
            return View();
        }
    }
}