using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkSpaceManagemetApi.DataAccess;
using WorkSpaceManagemetApi.Models;

namespace WorkSpaceManagemetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeskBookingController : ControllerBase
    {
        private readonly WorkSpaceDbContext workspace;
        public DeskBookingController(WorkSpaceDbContext r)
        {
            workspace = r;
        }
        [HttpGet("AllBookedDesk")]
        public async Task<ActionResult> GetAllBookedDesk()
        {
            var desk = await workspace.deskBookings.ToListAsync();
            if (desk == null)
                return NotFound();
            return Ok(desk);
        }
        [HttpPost("BookDesk")]
        public async Task<ActionResult> BookDesk(DeskBooking r)
        {
            await workspace.deskBookings.AddAsync(r);
            workspace.SaveChanges();
            return Ok(r);
        }

    }
}
