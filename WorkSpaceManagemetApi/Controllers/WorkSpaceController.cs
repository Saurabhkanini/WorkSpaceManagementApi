using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkSpaceManagemetApi.Models;

namespace WorkSpaceManagemetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkSpaceController : ControllerBase
    {
        private readonly WsDbContext _dbContext;
        public WorkSpaceController(WsDbContext dbc)
        {
            this._dbContext = dbc;  

        }
         [HttpGet("location/employee")]
         public async Task<ActionResult> getEmployeesByLocation(string locationName)
        {
            var employees=_dbContext.employees.Include(x=>x.location).FirstOrDefault(x=>x.location.City==locationName);
            if(employees==null)
            {
                return NotFound($"No Employee Found With LocationName {locationName}");
            }
            return Ok(employees);
        }
    }
}
