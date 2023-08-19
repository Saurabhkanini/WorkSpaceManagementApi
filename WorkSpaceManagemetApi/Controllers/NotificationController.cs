using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkSpaceManagemetApi.Models;
using WorkSpaceManagemetApi.Repository;

namespace WorkSpaceManagemetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotification _notificationRepo;

        public NotificationController(INotification notificationRepo)
        {
            _notificationRepo = notificationRepo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Notification>> GetAllNotifications()
        {
            var notifications = _notificationRepo.GetAllNotification();
            if (notifications == null)
            {
                return NotFound();
            }
            return Ok(notifications);
        }

        [HttpGet("{id}")]
        public ActionResult<Notification> GetNotificationById(int id)
        {
            var notification = _notificationRepo.GetNotification(id);
            if (notification == null)
            {
                return NotFound();
            }
            return Ok(notification);
        }

        [HttpPost]
        public ActionResult<Notification> AddNotification(Notification notification)
        {
            var addedNotification = _notificationRepo.AddNotification(notification);
            if (addedNotification == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(GetNotificationById), new { id = addedNotification.NotificationId }, addedNotification);
        }

        [HttpPut("{id}")]
        public ActionResult<Notification> UpdateNotification(int id, Notification notification)
        {
            var updatedNotification = _notificationRepo.UpdateNotification(notification, id);
            if (updatedNotification == null)
            {
                return NotFound();
            }
            return Ok(updatedNotification);
        }

        [HttpDelete("{id}")]
        public ActionResult<Notification> DeleteNotification(int id)
        {
            var deletedNotification = _notificationRepo.DeleteNotification(id);
            if (deletedNotification == null)
            {
                return NotFound();
            }
            return Ok(deletedNotification);
        }
    }
}
