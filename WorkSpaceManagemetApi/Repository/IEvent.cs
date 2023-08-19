using WorkSpaceManagemetApi.Models;

namespace WorkSpaceManagemetApi.Repository
{
    public interface IEvent
    {
        IEnumerable<Events> GetAllEvents();
        Events GetEvent(int id);
        Events AddEvent(Events e);
        Events UpdateEvent(Events e, int id);
        Events DeleteEvent(int id);
    }
}
