using WorkSpaceManagemetApi.Models;

namespace WorkSpaceManagemetApi.Repository
{
    public interface ILocation
    {
        IEnumerable<Location> GetAllLocation();
        Location GetLocation(int id);
        Location AddLocation(Location loc);
        Location UpdateLocation(Location loc, int id);
        Location DeleteLocation(int id);
    }
}
