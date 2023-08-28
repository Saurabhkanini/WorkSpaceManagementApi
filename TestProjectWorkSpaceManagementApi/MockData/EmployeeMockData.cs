using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkSpaceManagemetApi.Models;

namespace TestProjectWorkSpaceManagementApi.MockData
{
    internal class EmployeeMockData
    {
        public static List<Employee> GetAllEmployeesMockData()
        {
            return new List<Employee>
            {
               new Employee
               {
                    EmployeeId = 1,
                    Fname = "saalsafal",
                    Lname = "sing",
                    LocationId = 2,
                    DepId = 3,
                    Email = "john.doe@example.com",
                    Phone = "123-456-7890",
                    AddPassword = "secret",
                    Title = "Software Engineer",
                    imageData = "image"

               },
                new Employee
               {
                    EmployeeId = 2,
                    Fname = "Singham",
                    Lname = "sing",
                    LocationId = 3,
                    DepId = 4,
                    Email = "jsing.doe@example.com",
                    Phone = "123-456-7890",
                    AddPassword = "secret",
                    Title = "Software Engineer",
                    imageData = "image"

               }

            };
        }
    }
}

