using WorkSpaceManagemetApi.Models;

namespace WorkSpaceManagemetApi.Repository
{
    public interface INotification
    {
        IEnumerable<Notification> GetAllNotification();
        Notification GetNotification(int id);
        Notification AddNotification(Notification loc);
        Notification UpdateNotification(Notification loc, int id);
        Notification DeleteNotification(int id);
    }
}
