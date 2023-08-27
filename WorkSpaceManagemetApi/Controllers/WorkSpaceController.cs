using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkSpaceManagemetApi.Models;

namespace WorkSpaceManagemetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkSpaceController : ControllerBase
    {
        private readonly WsDbContext _dbContext;
        public WorkSpaceController(WsDbContext dbc)
        {
            this._dbContext = dbc;  

        }
         [HttpGet("employee/location")]
         public async Task<ActionResult> getEmployeesByLocation(string locationName)
        {
            var employees=_dbContext.employees.Where(x=>x.location.City==locationName).ToList();
            if(employees==null)
            {
                return NotFound($"No Employee Found With LocationName {locationName}");
            }
            return Ok(employees);
        }
        [HttpGet("event/location")]
        public async Task<ActionResult> GetEventsByLocation(string locationName)
        {
            var events = await _dbContext.events
                           .Where(e => e.location.City.ToLower() == locationName.ToLower())
                           .ToListAsync();
            if (events == null)
            {
                return NotFound($"No Events found In {locationName}");
            }
            return Ok(events);

        }
        [HttpGet("notification/location")]
        public async Task<ActionResult> GetNotificationByLocation(string locationName)
        {
            var notifications = await _dbContext.notifications
                           .Where(e => e.location.City.ToLower() == locationName.ToLower()).Include(x=>x.location)
                           .ToListAsync();
            if (notifications == null)
            {
                return NotFound($"No Notification found In {locationName}");
            }
            return Ok(notifications);

        }
    }
}
