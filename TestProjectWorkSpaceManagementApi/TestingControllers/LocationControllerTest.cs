using Microsoft.AspNetCore.Mvc;
using Moq;
using WorkSpaceManagemetApi.Controllers;
using WorkSpaceManagemetApi.Models;
using WorkSpaceManagemetApi.Repository;

namespace TestProjectWorkSpaceManagementApi
{
    public class LocationControllerTests
    {
        [Fact]
        public void GetAllLocations_ReturnsAllLocations()
        {
            var mockLocations = LocationMockData.GetAllLocationsMockData();
            var mockLocationRepo = new Mock<ILocation>();
            mockLocationRepo.Setup(repo => repo.GetAllLocation()).Returns(mockLocations);
            var locationController = new LocationController(mockLocationRepo.Object);

            var result = locationController.GetAllLocations();

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedLocations = Assert.IsAssignableFrom<IEnumerable<Location>>(okResult.Value);
            Assert.Equal(mockLocations.Count, returnedLocations.Count());
        }

        [Fact]
        public void GetLocationById_ExistingId_ReturnsOkResult_WithLocation()
        {
            var mockLocations = LocationMockData.GetAllLocationsMockData();
            var mockLocationRepo = new Mock<ILocation>();
            mockLocationRepo.Setup(repo => repo.GetLocation(It.IsAny<int>()))
                            .Returns<int>(id => mockLocations.FirstOrDefault(l => l.Location_Id == id));

            var locationController = new LocationController(mockLocationRepo.Object);

            var existingLocationId = 1; 
            var result = locationController.GetLocationById(existingLocationId);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedLocation = Assert.IsAssignableFrom<Location>(okResult.Value);
            Assert.Equal(existingLocationId, returnedLocation.Location_Id);
        }

        [Fact]
        public void AddLocation_ValidData_ReturnsOkResult_WithNewLocation()
        {
            var newLocation = new Location
            {
                Location_Id = 3,
                FloorNumberOrBuildingName = "New Building SPOS",
                StreetAddress = "123 Oak St",
                City = "Pune",
                State = "Stateville",
                Pincode = 54321,
                Country = "Maryland"

            };

            var mockLocationRepo = new Mock<ILocation>();
            mockLocationRepo.Setup(repo => repo.AddLocation(It.IsAny<Location>())).Returns(newLocation);

            var locationController = new LocationController(mockLocationRepo.Object);

            var result = locationController.AddLocation(newLocation);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedLocation = Assert.IsAssignableFrom<Location>(okResult.Value);
            Assert.Equal(newLocation.Location_Id, returnedLocation.Location_Id);
        }

        [Fact]
        public void UpdateLocation_ExistingId_ValidData_ReturnsOkResult_WithUpdatedLocation()
        {
            var existingLocationId = 2;
            var updatedLocation = new Location
            {
                Location_Id = existingLocationId,
                FloorNumberOrBuildingName = "Updated Building",
                StreetAddress = "987 Elm St",
                City = "Updated City",
                State = "Updated State",
                Pincode = 12345,
                Country = "Updated Country"
            };

            var mockLocationRepo = new Mock<ILocation>();
            mockLocationRepo.Setup(repo => repo.UpdateLocation(It.IsAny<Location>(), It.IsAny<int>())).Returns(updatedLocation);

            var locationController = new LocationController(mockLocationRepo.Object);

            var result = locationController.UpdateLocation(existingLocationId, updatedLocation);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedLocation = Assert.IsAssignableFrom<Location>(okResult.Value);
            Assert.Equal(existingLocationId, returnedLocation.Location_Id);
        }

        [Fact]
        public void DeleteLocation_ExistingId_ReturnsOkResult_WithDeletedLocation()
        {

            var mockLocation = LocationMockData.GetAllLocationsMockData();
            var mockLocationRepo = new Mock<ILocation>();
            mockLocationRepo.Setup(repo => repo.DeleteLocation(It.IsAny<int>()))
                            .Returns<int>(id =>
                            {
                                var deletedLocation = mockLocation.FirstOrDefault(e => e.Location_Id == id);
                                if (deletedLocation != null)
                                {
                                    mockLocation.Remove(deletedLocation);
                                }
                                return deletedLocation;
                            });

            var locationController = new LocationController(mockLocationRepo.Object);

            var existingLocationId = 1;

            var result = locationController.DeleteLocation(existingLocationId);


            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var deletedLocation = Assert.IsAssignableFrom<Location>(okResult.Value);
            Assert.Equal(existingLocationId, deletedLocation.Location_Id);
            Assert.DoesNotContain(mockLocation, e => e.Location_Id == existingLocationId);
        }
    }
}
