using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestMakeAnAPI.Models;


namespace TestMakeAnAPI.Controllers
{
    public class GenresController : ApiController
    {
        private DevBuildMoviesDBEntities db = new DevBuildMoviesDBEntities();
        public IQueryable<string> GetGenres()
        {
            return db.Movies.Select(m => m.Genre).Distinct();
        }
    }
}
