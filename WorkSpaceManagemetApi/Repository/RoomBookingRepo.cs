using WorkSpaceManagemetApi.Models;

namespace WorkSpaceManagemetApi.Repository
{
    public class RoomBookingRepo:IRoomBooking
    {
        private readonly WsDbContext _dbContext;

        public RoomBookingRepo(WsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<RoomBooking> GetAllRbooking()
        {
            try
            {
                return _dbContext.roomBooking.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while retrieving all room bookings: " + ex.Message);
                return null;
            }
        }

        public RoomBooking GetRbooking(int id)
        {
            try
            {
                return _dbContext.roomBooking.Find(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while retrieving the room booking by ID: " + ex.Message);
                return null;
            }
        }

        public RoomBooking BookRoom(RoomBooking rb)
        {
            try
            {
                _dbContext.roomBooking.Add(rb);
                _dbContext.SaveChanges();
                return rb;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while booking the room: " + ex.Message);
                return null;
            }
        }

        public RoomBooking UpdateRbookingDetail(RoomBooking rb, int id)
        {
            try
            {
                RoomBooking existingBooking = _dbContext.roomBooking.Find(id);
                if (existingBooking != null)
                {
                    existingBooking.MeetingTitle = rb.MeetingTitle;
                    // Update other properties of the booking here
                    _dbContext.SaveChanges();
                }
                return existingBooking;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while updating the room booking: " + ex.Message);
                return null;
            }
        }

        public RoomBooking DeleteBooking(int id)
        {
            try
            {
                RoomBooking bookingToDelete = _dbContext.roomBooking.Find(id);
                if (bookingToDelete != null)
                {
                    _dbContext.roomBooking.Remove(bookingToDelete);
                    _dbContext.SaveChanges();
                }
                return bookingToDelete;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while deleting the room booking: " + ex.Message);
                return null;
            }
        }
    }
}
