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
using TestMakeAnAPI.Models;

namespace TestMakeAnAPI.Controllers
{
    public class DirectorsController : ApiController
    {
        private DevBuildMoviesDBEntities db = new DevBuildMoviesDBEntities();

        // GET: api/Directors
        public IQueryable<Director> GetDirectors()
        {
            return db.Directors;
        }

        // GET: api/Directors/5
        [ResponseType(typeof(Director))]
        public IHttpActionResult GetDirector(int id)
        {
            Director director = db.Directors.Find(id);
            if (director == null)
            {
                return NotFound();
            }

            return Ok(director);
        }

        // PUT: api/Directors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDirector(int id, Director director)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != director.DirectorID)
            {
                return BadRequest();
            }

            db.Entry(director).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DirectorExists(id))
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

        // POST: api/Directors
        [ResponseType(typeof(Director))]
        public IHttpActionResult PostDirector(Director director)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Directors.Add(director);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = director.DirectorID }, director);
        }

        // DELETE: api/Directors/5
        [ResponseType(typeof(Director))]
        public IHttpActionResult DeleteDirector(int id)
        {
            Director director = db.Directors.Find(id);
            if (director == null)
            {
                return NotFound();
            }

            db.Directors.Remove(director);
            db.SaveChanges();

            return Ok(director);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DirectorExists(int id)
        {
            return db.Directors.Count(e => e.DirectorID == id) > 0;
        }
    }
}