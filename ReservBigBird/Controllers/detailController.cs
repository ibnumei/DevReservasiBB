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
    public class detailController : Controller
    {
        private devbigbirdEntities1 db = new devbigbirdEntities1();

        // GET: detail
        public ActionResult Index()
        {
            return View(db.LoginNewTbls.ToList());
        }

        // GET: detail/Details/5
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

        // GET: detail/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: detail/Create
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

        // GET: detail/Edit/5
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

        // POST: detail/Edit/5
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

        // GET: detail/Delete/5
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

        // POST: detail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LoginNewTbl loginNewTbl = db.LoginNewTbls.Find(id);
            db.LoginNewTbls.Remove(loginNewTbl);
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
