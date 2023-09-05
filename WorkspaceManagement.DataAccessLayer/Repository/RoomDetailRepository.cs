using Microsoft.EntityFrameworkCore;
using WorkspaceManagement.DataAccessLayer.Data;
using WorkspaceManagement.DataAccessLayer.Interfaces;
using WorkspaceManagement.DataAccessLayer.Models;
namespace WorkSpaceManagemetApi.Repository
{
    public class RoomDetailRepository:IRoomDetail
    {
        private readonly WorkSpaceDbContext _dbContext;

        public RoomDetailRepository(WorkSpaceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<RoomDetail> GetAllRooms()
        {
            try
            {
                return _dbContext.RoomDetail.Include(x=>x.Location).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public RoomDetail GetRoomDetail(int id)
        {
            try
            {
                return _dbContext.RoomDetail.Include(x=>x.Location).FirstOrDefault(x=>x.RoomId==id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public RoomDetail AddRoom(RoomDetail rd)
        {
            try
            {
                _dbContext.RoomDetail.Add(rd);
                _dbContext.SaveChanges();
                return rd;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public RoomDetail UpdateRoomDetail(RoomDetail rd, int id)
        {
            try
            {
                RoomDetail existingRoom = _dbContext.RoomDetail.Find(id);
                if (existingRoom != null)
                {
                    existingRoom.RoomName = rd.RoomName;
                    _dbContext.SaveChanges();
                }
                return existingRoom;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public RoomDetail DeleteRoom(int id)
        {
            try
            {
                RoomDetail roomToDelete = _dbContext.RoomDetail.Find(id);
                if (roomToDelete != null)
                {
                    _dbContext.RoomDetail.Remove(roomToDelete);
                    _dbContext.SaveChanges();
                }
                return roomToDelete;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
