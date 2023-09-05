using Microsoft.EntityFrameworkCore;
using WorkspaceManagement.DataAccessLayer.Data;
using WorkspaceManagement.DataAccessLayer.Interfaces;
using WorkspaceManagement.DataAccessLayer.Models;
namespace WorkSpaceManagemetApi.Repository
{
    public class EmployeeRepository:IEmployee
    {
        private readonly WorkSpaceDbContext _dbContext;

        public EmployeeRepository(WorkSpaceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public  IEnumerable<Employee> GetAllEmployee()
        {
            try
            {
                return  _dbContext.Employees.Include(x=>x.Department).Include(x=>x.Location).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Employee GetEmployee(int id)
        {
            try
            {
                return _dbContext.Employees.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Employee AddEmployee(Employee employee)
        {
            try
            {
                _dbContext.Employees.Add(employee);
                _dbContext.SaveChanges();
                return employee;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Employee UpdateEmployee(Employee employee, int id)
        {
            try
            {
                Employee existingEmployee = _dbContext.Employees.Find(id);
                if (existingEmployee != null)
                {
                    existingEmployee.Fname = employee.Fname;
                    existingEmployee.Email = employee.Email;
                    // Update other properties of the employee here
                    _dbContext.SaveChanges();
                }
                return existingEmployee;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Employee DeleteEmployee(int id)
        {
            try
            {
                Employee employeeToRemove = _dbContext.Employees.Find(id);
                if (employeeToRemove != null)
                {
                    _dbContext.Employees.Remove(employeeToRemove);
                    _dbContext.SaveChanges();
                }
                return employeeToRemove;
            }
            catch (Exception ex)
            {
                throw new Exception (ex.Message);
            }
        }

    }
}
