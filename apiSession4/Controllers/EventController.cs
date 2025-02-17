using apiSession4.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace apiSession4.Controllers
{
    [ApiController]
    public class EventController : ControllerBase
    {
        private RoadOfRussiaContext db;
        public EventController(RoadOfRussiaContext db)
        {
            this.db = db;
        }
        [HttpGet]
        [Route("Events")]
        public IQueryable GetEvents()
        {
            var ev = from e in db.Events
                      select new
                      {
                          e.IdEvent,
                          e.EventName,
                          e.TypeOfEvent,
                          e.EventStatus,
                          e.EventDescription,
                          e.DateOfEvent,
                          e.EventManagers,
                          e.TypeOfClass
                      };
            return ev.AsQueryable();

        }

    }
}
