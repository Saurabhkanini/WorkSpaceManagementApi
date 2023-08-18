using WorkSpaceManagemetApi.Models;

namespace WorkSpaceManagemetApi.Repository
{
    public class EmployeeRepo:IEmployee
    {
        private readonly WsDbContext _dbContext;

        public EmployeeRepo(WsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            try
            {
                return _dbContext.employees.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while retrieving all employees: " + ex.Message);
                return null;
            }
        }

        public Employee GetEmployee(int id)
        {
            try
            {
                return _dbContext.employees.Find(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while retrieving the employee by ID: " + ex.Message);
                return null;
            }
        }

        public Employee AddEmployee(Employee employee)
        {
            try
            {
                _dbContext.employees.Add(employee);
                _dbContext.SaveChanges();
                return employee;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while adding the employee: " + ex.Message);
                return null;
            }
        }

        public Employee UpdateEmployee(Employee employee, int id)
        {
            try
            {
                Employee existingEmployee = _dbContext.employees.Find(id);
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
                Console.WriteLine("An error occurred while updating the employee: " + ex.Message);
                return null;
            }
        }

        public Employee DeleteEmployee(int id)
        {
            try
            {
                Employee employeeToRemove = _dbContext.employees.Find(id);
                if (employeeToRemove != null)
                {
                    _dbContext.employees.Remove(employeeToRemove);
                    _dbContext.SaveChanges();
                }
                return employeeToRemove;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while deleting the employee: " + ex.Message);
                return null;
            }
        }

    }
}
