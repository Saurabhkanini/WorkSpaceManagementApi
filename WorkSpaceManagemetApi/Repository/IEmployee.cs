using WorkSpaceManagemetApi.Models;

namespace WorkSpaceManagemetApi.Repository
{
    public interface IEmployee
    {
        IEnumerable<Employee> GetAllEmployee();
        Employee GetEmployee(int id);
        Employee AddEmployee(Employee employee);
        Employee UpdateEmployee(Employee employee, int id);
        Employee DeleteEmployee(int id);
    }
}
