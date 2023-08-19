using WorkSpaceManagemetApi.Models;

namespace WorkSpaceManagemetApi.Repository
{
    public class DeskBookingRepo
    {
        private readonly WsDbContext _dbContext;

        public DeskBookingRepo(WsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<DeskBooking> GetAllDbooking()
        {
            try
            {
                return _dbContext.deskBookings.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while retrieving all desk bookings: " + ex.Message);
                return null;
            }
        }

        public DeskBooking GetDbooking(int id)
        {
            try
            {
                return _dbContext.deskBookings.Find(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while retrieving the desk booking by ID: " + ex.Message);
                return null;
            }
        }

        public DeskBooking BookDesk(DeskBooking db)
        {
            try
            {
                _dbContext.deskBookings.Add(db);
                _dbContext.SaveChanges();
                return db;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while booking the desk: " + ex.Message);
                return null;
            }
        }

        public DeskBooking UpdateDbookingDetail(DeskBooking db, int id)
        {
            try
            {
                DeskBooking existingBooking = _dbContext.deskBookings.Find(id);
                if (existingBooking != null)
                {
                    existingBooking.BookingDate = db.BookingDate;
                    _dbContext.SaveChanges();
                }
                return existingBooking;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while updating the desk booking: " + ex.Message);
                return null;
            }
        }

        public DeskBooking DeleteBooking(int id)
        {
            try
            {
                DeskBooking bookingToDelete = _dbContext.deskBookings.Find(id);
                if (bookingToDelete != null)
                {
                    _dbContext.deskBookings.Remove(bookingToDelete);
                    _dbContext.SaveChanges();
                }
                return bookingToDelete;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while deleting the desk booking: " + ex.Message);
                return null;
            }
        }
    }
}
