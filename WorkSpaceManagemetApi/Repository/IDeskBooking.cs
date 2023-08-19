using WorkSpaceManagemetApi.Models;

namespace WorkSpaceManagemetApi.Repository
{
    public interface IDeskBooking
    {
        IEnumerable<DeskBooking> GetAllDbooking();
        DeskBooking GetDbooking(int id);
        DeskBooking BookDesk(DeskBooking db);
        DeskBooking UpdateDbookingDetail(DeskBooking db, int id);
        DeskBooking DeleteBooking(int id);
    }
}
