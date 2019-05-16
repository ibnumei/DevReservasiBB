using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ReservBigBird;

namespace ReservBigBird.Controllers
{
    public class APILoginNewTblsController : ApiController
    {
        private devbigbirdEntities1 db = new devbigbirdEntities1();

        // GET: api/APILoginNewTbls
        public IQueryable<LoginNewTbl> GetLoginNewTbls()
        {
            return db.LoginNewTbls;
        }

        // GET: api/APILoginNewTbls/5
        [ResponseType(typeof(LoginNewTbl))]
        public IHttpActionResult GetLoginNewTbl(int id)
        {
            LoginNewTbl loginNewTbl = db.LoginNewTbls.Find(id);
            if (loginNewTbl == null)
            {
                return NotFound();
            }

            return Ok(loginNewTbl);
        }

        // PUT: api/APILoginNewTbls/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLoginNewTbl(int id, LoginNewTbl loginNewTbl)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != loginNewTbl.id)
            {
                return BadRequest();
            }

            db.Entry(loginNewTbl).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoginNewTblExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/APILoginNewTbls
        [ResponseType(typeof(LoginNewTbl))]
        public IHttpActionResult PostLoginNewTbl(LoginNewTbl loginNewTbl)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LoginNewTbls.Add(loginNewTbl);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = loginNewTbl.id }, loginNewTbl);
        }

        // DELETE: api/APILoginNewTbls/5
        [ResponseType(typeof(LoginNewTbl))]
        public IHttpActionResult DeleteLoginNewTbl(int id)
        {
            LoginNewTbl loginNewTbl = db.LoginNewTbls.Find(id);
            if (loginNewTbl == null)
            {
                return NotFound();
            }

            db.LoginNewTbls.Remove(loginNewTbl);
            db.SaveChanges();

            return Ok(loginNewTbl);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LoginNewTblExists(int id)
        {
            return db.LoginNewTbls.Count(e => e.id == id) > 0;
        }
    }
}