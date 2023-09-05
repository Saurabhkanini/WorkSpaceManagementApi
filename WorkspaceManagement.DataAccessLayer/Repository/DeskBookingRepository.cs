using WorkspaceManagement.DataAccessLayer.Data;
using WorkspaceManagement.DataAccessLayer.Interfaces;
using WorkspaceManagement.DataAccessLayer.Models;

namespace WorkSpaceManagemetApi.Repository
{
    public class DeskBookingRepository:IDeskBooking
    {
        private readonly WorkSpaceDbContext _dbContext;

        public DeskBookingRepository(WorkSpaceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<DeskBooking> GetAllDbooking()
        {
            try
            {
                return _dbContext.DeskBookings.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DeskBooking GetDbooking(int id)
        {
            try
            {
                return _dbContext.DeskBookings.Find(id);
            }
            catch (Exception ex)
            {
              throw new Exception (ex.Message);
            }
        }

        public DeskBooking BookDesk(DeskBooking db)
        {
            try
            {
                _dbContext.DeskBookings.Add(db);
                _dbContext.SaveChanges();
                return db;
            }
            catch (Exception ex)
            {
                throw new Exception (ex.Message);

            }
        }

        public DeskBooking UpdateDbookingDetail(DeskBooking db, int id)
        {
            try
            {
                DeskBooking existingBooking = _dbContext.DeskBookings.Find(id);
                if (existingBooking != null)
                {
                    existingBooking.BookingDate = db.BookingDate;
                    _dbContext.SaveChanges();
                }
                return existingBooking;
            }
            catch (Exception ex)
            {
                throw new Exception (ex.Message);

            }
        }

        public DeskBooking DeleteBooking(int id)
        {
            try
            {
                DeskBooking bookingToDelete = _dbContext.DeskBookings.Find(id);
                if (bookingToDelete != null)
                {
                    _dbContext.DeskBookings.Remove(bookingToDelete);
                    _dbContext.SaveChanges();
                }
                return bookingToDelete;
            }
            catch (Exception ex)
            {
                throw (ex);

            }
        }
    }
}
