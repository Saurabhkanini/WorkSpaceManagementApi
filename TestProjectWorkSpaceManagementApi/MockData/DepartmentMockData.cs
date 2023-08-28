using System.Collections.Generic;
using WorkSpaceManagemetApi.Models;

namespace TestProjectWorkSpaceManagementApi
{
    internal class DepartmentMockData
    {
        public static List<Department> GetAllDepartmentsMockData()
        {
            return new List<Department>
            {
                new Department
                {
                    DeptId = 1,
                    DeptName = "Department A",
                },
                new Department
                {
                    DeptId = 2,
                    DeptName = "Department B",
                },
                new Department
                {
                    DeptId = 3,
                    DeptName = "Department cd",
                }
            };
        }
    }
}
