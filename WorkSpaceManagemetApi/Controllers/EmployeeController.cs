using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkSpaceManagemetApi.Models;
using WorkSpaceManagemetApi.Repository;

namespace WorkSpaceManagemetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee _employeeRepo;

        public EmployeeController(IEmployee employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetAllEmployees()
        {
            var employees = _employeeRepo.GetAllEmployee();
            if (employees == null)
            {
                return NotFound();
            }
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployeeById(int id)
        {
            var employee = _employeeRepo.GetEmployee(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]
        public ActionResult<Employee> AddEmployee(Employee employee)
        {
            var addedEmployee = _employeeRepo.AddEmployee(employee);
            if (addedEmployee == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(GetEmployeeById), new { id = addedEmployee.EmployeeId }, addedEmployee);
        }

        [HttpPut("{id}")]
        public ActionResult<Employee> UpdateEmployee(int id, Employee employee)
        {
            var updatedEmployee = _employeeRepo.UpdateEmployee(employee, id);
            if (updatedEmployee == null)
            {
                return NotFound();
            }
            return Ok(updatedEmployee);
        }

        [HttpDelete("{id}")]
        public ActionResult<Employee> DeleteEmployee(int id)
        {
            var deletedEmployee = _employeeRepo.DeleteEmployee(id);
            if (deletedEmployee == null)
            {
                return NotFound();
            }
            return Ok(deletedEmployee);
        }
    }
}
