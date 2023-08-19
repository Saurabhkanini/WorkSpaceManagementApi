using WorkSpaceManagemetApi.Models;

namespace WorkSpaceManagemetApi.Repository
{
    public interface IRoomDetail
    {
        IEnumerable<RoomDetail> GetAllRooms();
        RoomDetail GetRoomDetail(int id);
        RoomDetail AddRoom(RoomDetail rd);
        RoomDetail UpdateRoomDetail(RoomDetail rd, int id);
        RoomDetail DeleteRoom(int id);
    }
}
