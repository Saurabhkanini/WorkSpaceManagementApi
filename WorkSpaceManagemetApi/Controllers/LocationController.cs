using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkSpaceManagemetApi.Models;
using WorkSpaceManagemetApi.Repository;

namespace WorkSpaceManagemetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocation _locationRepo;

        public LocationController(ILocation locationRepo)
        {
            _locationRepo = locationRepo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Location>> GetAllLocations()
        {
            var locations = _locationRepo.GetAllLocation();
            if (locations == null)
            {
                return NotFound();
            }
            return Ok(locations);
        }

        [HttpGet("{id}")]
        public ActionResult<Location> GetLocationById(int id)
        {
            var location = _locationRepo.GetLocation(id);
            if (location == null)
            {
                return NotFound();
            }
            return Ok(location);
        }

        [HttpPost]
        public ActionResult<Location> AddLocation(Location location)
        {
            var addedLocation = _locationRepo.AddLocation(location);
            if (addedLocation == null)
            {
                return BadRequest();
            }
            return Ok(addedLocation);
        }

        [HttpPut("{id}")]
        public ActionResult<Location> UpdateLocation(int id, Location location)
        {
            var updatedLocation = _locationRepo.UpdateLocation(location, id);
            if (updatedLocation == null)
            {
                return NotFound();
            }
            return Ok(updatedLocation);
        }

        [HttpDelete("{id}")]
        public ActionResult<Location> DeleteLocation(int id)
        {
            var deletedLocation = _locationRepo.DeleteLocation(id);
            if (deletedLocation == null)
            {
                return NotFound();
            }
            return Ok(deletedLocation);
        }

    }
}
