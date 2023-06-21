using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkSpaceManagemetApi.DataAccess;
using WorkSpaceManagemetApi.Models;

namespace WorkSpaceManagemetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly WorkSpaceDbContext workspace;
        public LocationController(WorkSpaceDbContext r)
        {
            workspace = r;
        }
        [HttpGet("All Locations")]
        public async Task<ActionResult> GetAllLocation()
        {
            var loc = await workspace.location.ToListAsync();
            if (loc == null)
                return NotFound();
            return Ok(loc);
        }
        [HttpPost("Add Location")]
        public async Task<ActionResult> AddLocation(Location l)
        {
            await workspace.location.AddAsync(l);
            workspace.SaveChanges();
            return Ok(l);
        }
    }
}
