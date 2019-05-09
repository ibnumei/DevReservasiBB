using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ReservBigBird;

namespace ReservBigBird.Controllers
{
    public class LoginNewController : Controller
    {
        private devbigbirdEntities db = new devbigbirdEntities();

        // GET: LoginNew
        public ActionResult Index()
        {
            return View();
            //return View();
        }

        public ActionResult NewIndex(DateTime a, DateTime b)
        {
            List<String> allDates = new List<String>();

            int starting = a.Day;
            int ending = b.Day;
            
            for (DateTime date = a; date <= b; date = date.AddDays(1))
            {
                allDates.Add(date.ToString("dd/MM/yyyy"));
            }

            ViewBag.tgl = allDates.ToList();
            var filter = db.LoginNewTbls.Where(s => s.username == "user1").ToList();
            return PartialView("NewIndex",filter);
        }

        // GET: LoginNew/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoginNewTbl loginNewTbl = db.LoginNewTbls.Find(id);
            if (loginNewTbl == null)
            {
                return HttpNotFound();
            }
            return View(loginNewTbl);
        }

        // GET: LoginNew/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoginNew/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,username,email,pass")] LoginNewTbl loginNewTbl)
        {
            if (ModelState.IsValid)
            {
                db.LoginNewTbls.Add(loginNewTbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loginNewTbl);
        }

        // GET: LoginNew/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoginNewTbl loginNewTbl = db.LoginNewTbls.Find(id);
            if (loginNewTbl == null)
            {
                return HttpNotFound();
            }
            return View(loginNewTbl);
        }

        // POST: LoginNew/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,username,email,pass")] LoginNewTbl loginNewTbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loginNewTbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loginNewTbl);
        }

        // GET: LoginNew/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoginNewTbl loginNewTbl = db.LoginNewTbls.Find(id);
            if (loginNewTbl == null)
            {
                return HttpNotFound();
            }
            return View(loginNewTbl);
        }

        // POST: LoginNew/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LoginNewTbl loginNewTbl = db.LoginNewTbls.Find(id);
            db.LoginNewTbls.Remove(loginNewTbl);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult LoadData()
        {
            var a = 10;
            try
            {
                var draw = HttpContext.Request.Form["draw"].FirstOrDefault();
                // Skiping number of Rows count  
                var start = Request.Form["start"].FirstOrDefault();
                // Paging Length 10,20  
                var length = Request.Form["length"].FirstOrDefault();
                // Sort Column Name  
                var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
                // Sort Column Direction ( asc ,desc)  
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
                // Search Value from (Search box)  
                var searchValue = Request.Form["search[value]"].FirstOrDefault();

                //Paging Size (10,20,50,100)  
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;

                // Getting all Customer data  
                var customerData = (from tempcustomer in db.LoginNewTbls
                                    select tempcustomer);

                ////Sorting
                //if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                //{
                //    customerData = customerData.OrderBy(sortColumn + " " + sortColumnDirection);
                //}
                //Search  
                if (!string.IsNullOrEmpty(searchValue.ToString()))
                {
                    //customerData = customerData.Where(m => m.SiteCode == searchValue);
                    customerData = customerData.Where(m => m.username.Contains(searchValue) || m.email.Contains(searchValue));
                }

                //total number of rows count   
                recordsTotal = customerData.Count();
                //Paging   
                var data = customerData.Skip(skip).Take(pageSize).ToList();
                //Returning Json Data  
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });

            }
            catch (Exception)
            {
                throw;
            }

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
