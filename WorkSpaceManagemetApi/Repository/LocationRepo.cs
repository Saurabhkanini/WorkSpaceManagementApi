using WorkSpaceManagemetApi.Models;

namespace WorkSpaceManagemetApi.Repository
{
    public class LocationRepo:ILocation
    {
        private readonly WsDbContext _dbContext;

        public LocationRepo(WsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Location> GetAllLocation()
        {
            try
            {
                return _dbContext.location.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while retrieving all locations: " + ex.Message);
                return null;
            }
        }

        public Location GetLocation(int id)
        {
            try
            {
                return _dbContext.location.Find(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while retrieving the location by ID: " + ex.Message);
                return null;
            }
        }

        public Location AddLocation(Location loc)
        {
            try
            {
                _dbContext.location.Add(loc);
                _dbContext.SaveChanges();
                return loc;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while adding the location: " + ex.Message);
                return null;
            }
        }

        public Location UpdateLocation(Location loc, int id)
        {
            try
            {
                Location existingLocation = _dbContext.location.Find(id);
                if (existingLocation != null)
                {
                    existingLocation.FloorNumberOrBuildingName = loc.FloorNumberOrBuildingName;
                    // Update other properties of the location here
                    _dbContext.SaveChanges();
                }
                return existingLocation;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while updating the location: " + ex.Message);
                return null;
            }
        }

        public Location DeleteLocation(int id)
        {
            try
            {
                Location locationToDelete = _dbContext.location.Find(id);
                if (locationToDelete != null)
                {
                    _dbContext.location.Remove(locationToDelete);
                    _dbContext.SaveChanges();
                }
                return locationToDelete;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while deleting the location: " + ex.Message);
                return null;
            }
        }
    }
}
