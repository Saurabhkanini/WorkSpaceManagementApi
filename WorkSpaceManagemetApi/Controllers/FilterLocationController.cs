using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkSpaceManagemetApi.Models;

namespace WorkSpaceManagemetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilterLocationController : ControllerBase
    {
        private readonly WsDbContext _dbContext;
        public FilterLocationController(WsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
       

        [HttpGet("api/employees/locations")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeesByLocations([FromQuery] List<string> locationNames)
        {
            var employees = _dbContext.employees
                .Where(e => e.location != null && locationNames.Contains(e.location.City))
                .ToList();

            if (employees.Count == 0)
            {
                return NotFound("No Employees Found in the Specified Locations");
            }

            return Ok(employees);
        }

    }
}
