using Microsoft.AspNetCore.Mvc;
using Moq;
using TestProjectWorkSpaceManagementApi.MockData;
using WorkSpaceManagemetApi.Controllers;
using WorkSpaceManagemetApi.Models;
using WorkSpaceManagemetApi.Repository;

namespace TestProjectWorkSpaceManagementApi.TestingControllers
{
    public class UnitTest1
    {

        [Fact]
        public void GetAllEmployees_ReturnsAllMockEmployees()
        {
            var mockEmployees = EmployeeMockData.GetAllEmployeesMockData();
            var mockEmployeeRepo = new Mock<IEmployee>();
            mockEmployeeRepo.Setup(repo => repo.GetAllEmployee()).Returns(mockEmployees);
            var employeeController = new EmployeeController(mockEmployeeRepo.Object);

            var result = employeeController.GetAllEmployees();

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedEmployees = Assert.IsAssignableFrom<IEnumerable<Employee>>(okResult.Value);
            Assert.Equal(mockEmployees.Count, returnedEmployees.Count());
        }

        [Fact]
        public void GetEmployeeById_ExistingId_ReturnsOkResult_WithEmployee()
        {
            var mockEmployees = EmployeeMockData.GetAllEmployeesMockData();
            var mockEmployeeRepo = new Mock<IEmployee>();
            mockEmployeeRepo.Setup(repo => repo.GetEmployee(It.IsAny<int>()))
                            .Returns<int>(id => mockEmployees.FirstOrDefault(e => e.EmployeeId == id));

            var employeeController = new EmployeeController(mockEmployeeRepo.Object);

            var existingEmployeeId = 1;

            var result = employeeController.GetEmployeeById(existingEmployeeId);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedEmployee = Assert.IsAssignableFrom<Employee>(okResult.Value);
            Assert.Equal(existingEmployeeId, returnedEmployee.EmployeeId);
        }

        [Fact]
        public void AddEmployee_ValidData_ReturnsCreatedAtActionResult_WithNewEmployee()
        {

            var mockEmployees = EmployeeMockData.GetAllEmployeesMockData();
            var mockEmployeeRepo = new Mock<IEmployee>();
            mockEmployeeRepo.Setup(repo => repo.AddEmployee(It.IsAny<Employee>()))
                            .Returns<Employee>(newEmployee =>
                            {
                                newEmployee.EmployeeId = mockEmployees.Max(e => e.EmployeeId) + 1;
                                mockEmployees.Add(newEmployee);
                                return newEmployee;
                            });

            var employeeController = new EmployeeController(mockEmployeeRepo.Object);

            var newEmployee = new Employee
            {
                Fname = "NiggaSing",
                Lname = "Joshi",
                LocationId = 4,
                DepId = 5,
                Email = "newee@gmail.com",
                Phone = "555-555-5555",
                AddPassword = "secret",
                Title = "Tester",
                imageData = "newimage",
            };


            var result = employeeController.AddEmployee(newEmployee);

            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var returnedEmployee = Assert.IsAssignableFrom<Employee>(createdAtActionResult.Value);
            Assert.Equal(mockEmployees.Count, returnedEmployee.EmployeeId);
        }


        [Fact]
        public void UpdateEmployee_ExistingId_ValidData_ReturnsOkResult_WithUpdatedEmployee()
        {
            var mockEmployees = EmployeeMockData.GetAllEmployeesMockData();
            var mockEmployeeRepo = new Mock<IEmployee>();
            mockEmployeeRepo.Setup(repo => repo.UpdateEmployee(It.IsAny<Employee>(), It.IsAny<int>()))
                            .Returns<Employee, int>((updatedEmployee, id) =>
                            {
                                var existingEmployee = mockEmployees.FirstOrDefault(e => e.EmployeeId == id);
                                if (existingEmployee != null)
                                {
                                    existingEmployee.Fname = updatedEmployee.Fname;
                                    existingEmployee.Lname = updatedEmployee.Lname;
                                    return existingEmployee;
                                }
                                return null;
                            });

            var employeeController = new EmployeeController(mockEmployeeRepo.Object);

            var existingEmployeeId = 1;
            var updatedEmployeeData = new Employee
            {
                Fname = "NeWSAfal",
                Lname = "Chaal",
                LocationId = 4,
                DepId = 5,
                Email = "safalchayak12@gmail.com",
                Phone = "555-555-5555",
                AddPassword = "secret",
                Title = "Tester",
                imageData = "updatedimage",
            };

            var result = employeeController.UpdateEmployee(existingEmployeeId, updatedEmployeeData);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedEmployee = Assert.IsAssignableFrom<Employee>(okResult.Value);
            Assert.Equal(existingEmployeeId, returnedEmployee.EmployeeId);
            Assert.Equal(updatedEmployeeData.Fname, returnedEmployee.Fname);
            Assert.Equal(updatedEmployeeData.Lname, returnedEmployee.Lname);
        }

        [Fact]
        public void DeleteEmployee_ExistingId_ReturnsOkResult_WithDeletedEmployee()
        {
            var mockEmployees = EmployeeMockData.GetAllEmployeesMockData();
            var mockEmployeeRepo = new Mock<IEmployee>();
            mockEmployeeRepo.Setup(repo => repo.DeleteEmployee(It.IsAny<int>()))
                            .Returns<int>(id =>
                            {
                                var deletedEmployee = mockEmployees.FirstOrDefault(e => e.EmployeeId == id);
                                if (deletedEmployee != null)
                                {
                                    mockEmployees.Remove(deletedEmployee);
                                }
                                return deletedEmployee;
                            });

            var employeeController = new EmployeeController(mockEmployeeRepo.Object);

            var existingEmployeeId = 1;

            var result = employeeController.DeleteEmployee(existingEmployeeId);


            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var deletedEmployee = Assert.IsAssignableFrom<Employee>(okResult.Value);
            Assert.Equal(existingEmployeeId, deletedEmployee.EmployeeId);
            Assert.DoesNotContain(mockEmployees, e => e.EmployeeId == existingEmployeeId);
        }
    }
}