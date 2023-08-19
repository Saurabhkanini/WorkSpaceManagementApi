using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkSpaceManagemetApi.Models;
using WorkSpaceManagemetApi.Repository;

namespace WorkSpaceManagemetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEvent _eventRepo;

        public EventController(IEvent eventRepo)
        {
            _eventRepo = eventRepo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Events>> GetAllEvents()
        {
            var events = _eventRepo.GetAllEvents();
            if (events == null)
            {
                return NotFound();
            }
            return Ok(events);
        }

        [HttpGet("{id}")]
        public ActionResult<Events> GetEventById(int id)
        {
            var evnt = _eventRepo.GetEvent(id);
            if (evnt == null)
            {
                return NotFound();
            }
            return Ok(evnt);
        }

        [HttpPost]
        public ActionResult<Events> AddEvent(Events evnt)
        {
            var addedEvent = _eventRepo.AddEvent(evnt);
            if (addedEvent == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(GetEventById), new { id = addedEvent.EventId }, addedEvent);
        }

        [HttpPut("{id}")]
        public ActionResult<Events> UpdateEvent(int id, Events evnt)
        {
            var updatedEvent = _eventRepo.UpdateEvent(evnt, id);
            if (updatedEvent == null)
            {
                return NotFound();
            }
            return Ok(updatedEvent);
        }

        [HttpDelete("{id}")]
        public ActionResult<Events> DeleteEvent(int id)
        {
            var deletedEvent = _eventRepo.DeleteEvent(id);
            if (deletedEvent == null)
            {
                return NotFound();
            }
            return Ok(deletedEvent);
        }

    }
}
