using WorkSpaceManagemetApi.Models;

namespace WorkSpaceManagemetApi.Repository
{
    public class RoomDetailRepo:IRoomDetail
    {
        private readonly WsDbContext _dbContext;

        public RoomDetailRepo(WsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<RoomDetail> GetAllRooms()
        {
            try
            {
                return _dbContext.roomDetail.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while retrieving all room details: " + ex.Message);
                return null;
            }
        }

        public RoomDetail GetRoomDetail(int id)
        {
            try
            {
                return _dbContext.roomDetail.Find(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while retrieving the room detail by ID: " + ex.Message);
                return null;
            }
        }

        public RoomDetail AddRoom(RoomDetail rd)
        {
            try
            {
                _dbContext.roomDetail.Add(rd);
                _dbContext.SaveChanges();
                return rd;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while adding the room detail: " + ex.Message);
                return null;
            }
        }

        public RoomDetail UpdateRoomDetail(RoomDetail rd, int id)
        {
            try
            {
                RoomDetail existingRoom = _dbContext.roomDetail.Find(id);
                if (existingRoom != null)
                {
                    existingRoom.RoomName = rd.RoomName;
                    // Update other properties of the room detail here
                    _dbContext.SaveChanges();
                }
                return existingRoom;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while updating the room detail: " + ex.Message);
                return null;
            }
        }

        public RoomDetail DeleteRoom(int id)
        {
            try
            {
                RoomDetail roomToDelete = _dbContext.roomDetail.Find(id);
                if (roomToDelete != null)
                {
                    _dbContext.roomDetail.Remove(roomToDelete);
                    _dbContext.SaveChanges();
                }
                return roomToDelete;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while deleting the room detail: " + ex.Message);
                return null;
            }
        }
    }
}
