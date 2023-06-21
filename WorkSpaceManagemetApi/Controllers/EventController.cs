using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkSpaceManagemetApi.DataAccess;
using WorkSpaceManagemetApi.Models;

namespace WorkSpaceManagemetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly WorkSpaceDbContext workspace;
        public EventController(WorkSpaceDbContext r)
        {
            workspace = r;
        }
        [HttpGet("AllEvents")]
        public async Task<ActionResult> GetAllEvents()
        {
            var eventt = await workspace.events.ToListAsync();
            if (eventt == null)
                return NotFound();
            return Ok(eventt);
        }
        [HttpPost("AddEvent")]
        public async Task<ActionResult> AddEvent(Events r)
        {
            await workspace.events.AddAsync(r);
            workspace.SaveChanges();
            return Ok(r);
        }

    }
}
