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
    public class MoviesController : ApiController
    {
        private DevBuildMoviesDBEntities db = new DevBuildMoviesDBEntities();

        // GET: api/Movies
        public IQueryable<Movie> GetMovies()
        {
            return db.Movies;
        }

        // GET: api/Movies?Category=...
        public IQueryable<Movie> GetMovies(string category)
        {
            return db.Movies.Where(m => m.Genre == category);
        }

        // GET: api/Movies?Amount=[# of randoms]
        public IQueryable<Movie> GetMovies(int amount)
        {
            Random random = new Random();

            return db.Movies.OrderBy(x => Guid.NewGuid()).Take(amount);
        }

        // GET: api/Movies?Amount=[# of randoms]&Category=...
        public IQueryable<Movie> GetMovies(int amount, string category)
        {
            Random random = new Random();

            return db.Movies.Where(m => m.Genre == category).OrderBy(x => Guid.NewGuid()).Take(amount);
        }

        // GET: api/Movies?Title=...
        public IQueryable<Movie> GetMoviesByTitle(string title)
        {
            return db.Movies.Where(m => m.Title.Contains(title));
        }

        // GET: api/Movies?ExactTitle=
        [ResponseType(typeof(Movie))]
        public IHttpActionResult GetMovie(string exactTitle)
        {
            Movie movie = db.Movies.FirstOrDefault(m => m.Title == exactTitle);
            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        // GET: api/Movies/5
        [ResponseType(typeof(Movie))]
        public IHttpActionResult GetMovie(int id)
        {
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        // PUT: api/Movies/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMovie(int id, Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != movie.MovieID)
            {
                return BadRequest();
            }

            db.Entry(movie).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
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

        // POST: api/Movies
        [ResponseType(typeof(Movie))]
        public IHttpActionResult PostMovie(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Movies.Add(movie);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = movie.MovieID }, movie);
        }

        // DELETE: api/Movies/5
        [ResponseType(typeof(Movie))]
        public IHttpActionResult DeleteMovie(int id)
        {
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return NotFound();
            }

            db.Movies.Remove(movie);
            db.SaveChanges();

            return Ok(movie);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MovieExists(int id)
        {
            return db.Movies.Count(e => e.MovieID == id) > 0;
        }
    }
}