using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkSpaceManagemetApi.DataAccess;
using WorkSpaceManagemetApi.Models;

namespace WorkSpaceManagemetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly WorkSpaceDbContext workspace;
        public NotificationController(WorkSpaceDbContext r)
        {
            workspace = r;
        }
        [HttpGet("All Notification")]
        public async Task<ActionResult> GetAllNotification()
        {
            var notif = await workspace.deskBookings.ToListAsync();
            if (notif == null)
                return NotFound();
            return Ok(notif);
        }
        [HttpPost("Add Notification")]
        public async Task<ActionResult> AddNotification(Notification r)
        {
            await workspace.notifications.AddAsync(r);
            workspace.SaveChanges();
            return Ok(r);
        }
    }
}
