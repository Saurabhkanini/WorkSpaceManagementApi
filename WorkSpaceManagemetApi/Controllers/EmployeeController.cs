using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkSpaceManagemetApi.DataAccess;
using WorkSpaceManagemetApi.Models;

namespace WorkSpaceManagemetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly WorkSpaceDbContext workspace;
        public EmployeeController(WorkSpaceDbContext r)
        {
            workspace = r;
        }
        [HttpGet("AllEmployee")]
        public async Task<ActionResult> GetAllEmp()
        {
            var emp = await workspace.employees.ToListAsync();
            if (emp == null)
                return NotFound();
            return Ok(emp);
        }
        [HttpPost("AddEmployee")]
        public async Task<ActionResult> AddEmp(Employee r)
        {
            await workspace.employees.AddAsync(r);
            workspace.SaveChanges();
            return Ok(r);
        }
    }
}
