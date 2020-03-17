using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LionsEventTracker.Models;
using LionsEventTracker.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LionsEventTracker.Controllers
{
    [Route("api/[controller]/[action]")]
    public class EventsController : Controller
    {
        private readonly DatabaseContext _context;

        public EventsController(DatabaseContext context)
        {
            _context = context;       
        }


        // GET: api/<controller>
        [HttpGet]
        [ActionName("GetEvents")]
        public ActionResult<List<Event>> GetEvents()
        {
            var eventsLists = _context.Events.ToList();

            foreach( var evt in eventsLists)
            {
                evt.Time = DateTime.Parse(evt.Time).ToString("hh:mm tt");

            }

            var events = eventsLists.OrderBy(eventList => eventList.Date).
               ThenBy(eventsList => eventsList.Time);

            return events.ToList();
        }

        // GET api/<controller>/5

        [HttpGet("{id}")]
        [ActionName("GetEventsById")]
        public IActionResult GetEventsById(int id)
        {
            var evnt = _context.Events.Include(x => x.eventUsers).Where(x => x.Id == id).FirstOrDefault();
            if (evnt == null)
            {
                return NotFound();
            }
            return Json(evnt);
        }
        // create event
        // POST api/<controller>
        [HttpPost]
        [ActionName("CreateEvent")]
        public void CreateEvent([FromBody]Event evnt)
        {
            if (evnt.Id > 0)
            {
                var eventToBeUpdated = _context.Events.Where(x => x.Id == evnt.Id).FirstOrDefault();

                eventToBeUpdated.Name = evnt.Name;
                eventToBeUpdated.Date = evnt.Date;
                eventToBeUpdated.Time = evnt.Time;
                eventToBeUpdated.Venue = evnt.Venue;
                eventToBeUpdated.Description = evnt.Description;
                eventToBeUpdated.Organization = evnt.Organization;

               _context.Events.Update(eventToBeUpdated);
               _context.SaveChanges();
            }
            else
            {
                _context.Events.Add(evnt);
                _context.SaveChanges();
            }
           
        }

        // POST api/<controller>
        
      // add user
        [HttpGet]
        [ActionName("Subscribe")]
        public void Subscribe(int eventId, int userId)
        {
            var newXref = new EventUser()
            {
                eventId = eventId,
                userId = userId
            };
            var user = _context.Users.Where(x => x.Id == userId).FirstOrDefault();
            var evt = _context.Events.Where(x => x.Id == eventId).FirstOrDefault();

            var foundEvent = _context.Events.Include(x => x.eventUsers).Where(x => x.Id == eventId).FirstOrDefault();
            if (foundEvent.eventUsers == null)
            {
                foundEvent.eventUsers = new List<EventUser>();
            }
           // foundEvent.eventUsers.Add(newXref);
           //_context.SaveChanges();
            MailSender.sendEmail(user.Email, "<p>Thank you for subscribing our event. Details of the event are as following: <br>" +" Name: " + evt.Name + "<br>" + " Date: " + evt.Date + "<br>" + " Time: " + DateTime.Parse(evt.Time).ToString("hh:mm tt") + "<br>" + " Venue " + evt.Venue + "<br>" + " Organizer: " + evt.Organization + "<p>");

        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Index(int id, Event evnt)
        {
            var eventInDb = _context.Events.Find(id);
            if (eventInDb == null)
            {
                return NotFound();
            }
            eventInDb.Name = evnt.Name;
            eventInDb.Date = evnt.Date;
            eventInDb.Time = evnt.Time;
            eventInDb.Venue = evnt.Venue;
            eventInDb.Description = evnt.Description;
            eventInDb.Organization = evnt.Organization;

            _context.Events.Update(eventInDb);
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var evnt = _context.Events.Find(id);
            if (evnt == null)
            {
                return NotFound();
            }

            _context.Events.Remove(evnt);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpGet]
        [ActionName("GetUpdate")]
        public IActionResult GetUpdate(int id)
        {
            var evntInTable = _context.Events.Find(id);
            if (evntInTable == null)
            {
                return NotFound();
            }
            return Json(evntInTable);

        }
        //[HttpPost]
        //[ActionName("SaveUpdate")]
        //public IActionResult SaveUpdate([FromBody]Event event)
        //{
        //    var updatedEvent = _context.Events.Include(x => x.eventUsers).Where(x => x.Id == id).FirstOrDefault();
        //    if (updatedEvent == null)
        //    {
        //        return NotFound();
        //    }
        //    updatedEvent.Name = evt.Name;
        //    updatedEvent.Date = evt.Date;
        //    updatedEvent.Time = evt.Time;
        //    updatedEvent.Venue = evt.Venue;
        //    updatedEvent.Description = evt.Description;
        //    updatedEvent.Organization = evt.Organization;

        //    _context.Events.Update(updatedEvent);
        //    _context.SaveChanges();
        //    return Ok();

        //}

    }
} 