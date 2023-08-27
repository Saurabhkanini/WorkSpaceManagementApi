using Microsoft.EntityFrameworkCore;
using WorkSpaceManagemetApi.Models;

namespace WorkSpaceManagemetApi.Repository
{
    public class NotificationRepo:INotification
    {
        private readonly WsDbContext _dbContext;

        public NotificationRepo(WsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Notification> GetAllNotification()
        {
            try
            {
                return _dbContext.notifications.Include(x=>x.location).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while retrieving all notifications: " + ex.Message);
                return null;
            }
        }

        public Notification GetNotification(int id)
        {
            try
            {
                return _dbContext.notifications.Find(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while retrieving the notification by ID: " + ex.Message);
                return null;
            }
        }

        public Notification AddNotification(Notification notification)
        {
            try
            {
                _dbContext.notifications.Add(notification);
                _dbContext.SaveChanges();
                return notification;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while adding the notification: " + ex.Message);
                return null;
            }
        }

        public Notification UpdateNotification(Notification notification, int id)
        {
            try
            {
                Notification existingNotification = _dbContext.notifications.Find(id);
                if (existingNotification != null)
                {
                    existingNotification.NotificationSubject = notification.NotificationSubject;
                    // Update other properties of the notification here
                    _dbContext.SaveChanges();
                }
                return existingNotification;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while updating the notification: " + ex.Message);
                return null;
            }
        }

        public Notification DeleteNotification(int id)
        {
            try
            {
                Notification notificationToDelete = _dbContext.notifications.Find(id);
                if (notificationToDelete != null)
                {
                    _dbContext.notifications.Remove(notificationToDelete);
                    _dbContext.SaveChanges();
                }
                return notificationToDelete;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while deleting the notification: " + ex.Message);
                return null;
            }
        }
    }
}
