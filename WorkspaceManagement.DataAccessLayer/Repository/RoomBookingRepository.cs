using Microsoft.EntityFrameworkCore;
using WorkspaceManagement.DataAccessLayer.Data;
using WorkspaceManagement.DataAccessLayer.Interfaces;
using WorkspaceManagement.DataAccessLayer.Models;
namespace WorkSpaceManagemetApi.Repository
{
    public class RoomBookingRepository:IRoomBooking
    {
        private readonly WorkSpaceDbContext _dbContext;

        public RoomBookingRepository(WorkSpaceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<RoomBooking> GetAllRbooking()
        {
            try
            {
                var roomBooking=_dbContext.RoomBooking.Include(x=>x.RoomDetail).ThenInclude(x=>x.Location).ToList();
                return roomBooking;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public RoomBooking GetRbooking(int id)
        {
            try
            {
                return _dbContext.RoomBooking.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public RoomBooking BookRoom(RoomBooking rb)
        {
            try
            {
                _dbContext.RoomBooking.Add(rb);
                _dbContext.SaveChanges();
                return rb;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public RoomBooking UpdateRbookingDetail(RoomBooking rb, int id)
        {
            try
            {
                RoomBooking existingBooking = _dbContext.RoomBooking.Find(id);
                if (existingBooking != null)
                {
                    existingBooking.MeetingTitle = rb.MeetingTitle;
                    _dbContext.SaveChanges();
                }
                return existingBooking;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public RoomBooking DeleteBooking(int id)
        {
            try
            {
                RoomBooking bookingToDelete = _dbContext.RoomBooking.Find(id);
                if (bookingToDelete != null)
                {
                    _dbContext.RoomBooking.Remove(bookingToDelete);
                    _dbContext.SaveChanges();
                }
                return bookingToDelete;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
