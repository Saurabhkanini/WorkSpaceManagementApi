using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkSpaceManagemetApi.DataAccess;
using WorkSpaceManagemetApi.Models;

namespace WorkSpaceManagemetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly WorkSpaceDbContext workspace;
        public RoomController(WorkSpaceDbContext r1)
        {
            workspace = r1;
        }
        [HttpGet("AllRooms")]
        public async Task<ActionResult> GetAllRooms()
        {
            var rooms = await workspace.roomDetail.ToListAsync();
            if (rooms == null)
                return NotFound();
            return Ok(rooms);
        }
        [HttpPost("AddRoom")]
        public async Task<ActionResult> AddRoom(RoomDetail r)
        {
            await workspace.roomDetail.AddAsync(r);
            workspace.SaveChanges();
            return Ok(r);
        }
    }
}
