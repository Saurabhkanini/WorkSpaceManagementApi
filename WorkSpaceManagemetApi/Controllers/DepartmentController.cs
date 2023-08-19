using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkSpaceManagemetApi.Models;

namespace WorkSpaceManagemetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly WsDbContext mytdb;
        public DepartmentController(WsDbContext mytrdb)
        {
            mytdb = mytrdb;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllDepartment()
        {
            var dept = await mytdb.department.ToListAsync();
            if (dept != null)
            {
                return Ok(dept);
            }
            return BadRequest("No Dept Found");

        }
        [HttpPost]
        public async Task<ActionResult> AddDepartment(Department ta)
        {
            await mytdb.department.AddAsync(ta);
            await mytdb.SaveChangesAsync();
            return Ok(ta);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateDepartment(Department ta, int id)
        {
            var dept = await mytdb.department.FindAsync(id);
            if (dept != null)
            {

                mytdb.department.Update(dept);
                mytdb.SaveChanges();
                return (Ok(dept));
            }
            return BadRequest($"Department Not found With Id={id}");

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDepartment(int id)
        {
            var dept = await mytdb.department.FindAsync(id);
            if (dept == null)
            {
                return BadRequest($"Department Not found With Id={id}");
            }
            mytdb.department.Remove(dept);
            mytdb.SaveChanges();
            return Ok(dept);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetDepartment(int id)
        {
            var dept = await mytdb.department.FindAsync(id);
            if (dept == null)
            {
                return BadRequest($"Department Not found With Id={id}");

            }
            return Ok(dept);
        }
    }
}
