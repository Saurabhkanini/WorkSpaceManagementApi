using WorkSpaceManagemetApi.Models;

namespace WorkSpaceManagemetApi.Repository
{
    public interface IRoomBooking
    {
        IEnumerable<RoomBooking> GetAllRbooking();
        RoomBooking GetRbooking(int id);
        RoomBooking BookRoom(RoomBooking db);
        RoomBooking UpdateRbookingDetail(RoomBooking db, int id);
        RoomBooking DeleteBooking(int id);
    }
}
