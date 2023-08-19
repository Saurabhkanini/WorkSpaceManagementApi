using WorkSpaceManagemetApi.Models;

namespace WorkSpaceManagemetApi.Repository
{
    public class EventRepo
    {
        private readonly WsDbContext _dbContext;

        public EventRepo(WsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Events> GetAllEvents()
        {
            try
            {
                return _dbContext.events.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while retrieving all events: " + ex.Message);
                return null;
            }
        }

        public Events GetEvent(int id)
        {
            try
            {
                return _dbContext.events.Find(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while retrieving the event by ID: " + ex.Message);
                return null;
            }
        }

        public Events AddEvent(Events e)
        {
            try
            {
                _dbContext.events.Add(e);
                _dbContext.SaveChanges();
                return e;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while adding the event: " + ex.Message);
                return null;
            }
        }

        public Events UpdateEvent(Events e, int id)
        {
            try
            {
                Events existingEvent = _dbContext.events.Find(id);
                if (existingEvent != null)
                {
                    existingEvent.EventTitle = e.EventTitle;
                    // Update other properties of the event here
                    _dbContext.SaveChanges();
                }
                return existingEvent;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while updating the event: " + ex.Message);
                return null;
            }
        }

        public Events DeleteEvent(int id)
        {
            try
            {
                Events eventToDelete = _dbContext.events.Find(id);
                if (eventToDelete != null)
                {
                    _dbContext.events.Remove(eventToDelete);
                    _dbContext.SaveChanges();
                }
                return eventToDelete;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while deleting the event: " + ex.Message);
                return null;
            }
        }
    }
}
