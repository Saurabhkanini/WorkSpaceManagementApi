using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkSpaceManagemetApi.DataAccess;
using WorkSpaceManagemetApi.Models;

namespace WorkSpaceManagemetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomBookingController : ControllerBase
    {
        private readonly WorkSpaceDbContext workspace;
        public RoomBookingController(WorkSpaceDbContext r)
        {
            workspace = r;
        }
        [HttpGet("AllBookedRooms")]
        public async Task<ActionResult> GetAllBookedRooms()
        {
            var rooms = await workspace.roomBooking.ToListAsync();
            if (rooms == null)
                return NotFound();
            return Ok(rooms);
        }
        [HttpPost("BookRoom")]
        public async Task<ActionResult> BookRoom(RoomBooking r)
        {
            await workspace.roomBooking.AddAsync(r);
            workspace.SaveChanges();
            return Ok(r);
        }

    }
}
