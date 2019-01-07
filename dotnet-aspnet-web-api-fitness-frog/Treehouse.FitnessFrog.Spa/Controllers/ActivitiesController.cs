using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using Treehouse.FitnessFrog.Shared.Data;

namespace Treehouse.FitnessFrog.Spa.Controllers
{
    public class ActivitiesController : ApiController
    {
        private ActivitiesRepository _activityRepository = null;

        public ActivitiesController(ActivitiesRepository activitiesRepository)
        {
            _activityRepository = activitiesRepository;
        }
        // GET: Activities
        public IHttpActionResult Get()
        {
            return Ok(_activityRepository.GetList());
        }
    }
}