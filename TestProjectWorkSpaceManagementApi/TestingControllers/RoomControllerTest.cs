using Microsoft.AspNetCore.Mvc;
using Moq;
using WorkSpaceManagemetApi.Controllers;
using WorkSpaceManagemetApi.Models;
using WorkSpaceManagemetApi.Repository;
using TestProjectWorkSpaceManagementApi.MockData;

namespace TestProjectWorkSpaceManagementApi
{
    public class RoomControllerTests
    {
        [Fact]
        public void GetAllRooms_ReturnsAllRooms()
        {
            var mockRoomDetails = RoomDetailMockData.GetMockRoomDetails();
            var mockRoomDetailRepo = new Mock<IRoomDetail>();
            mockRoomDetailRepo.Setup(repo => repo.GetAllRooms()).Returns(mockRoomDetails);
            var roomController = new RoomController(mockRoomDetailRepo.Object);

            var result = roomController.GetAllRooms();

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedRoomDetails = Assert.IsAssignableFrom<IEnumerable<RoomDetail>>(okResult.Value);
            Assert.Equal(mockRoomDetails.Count, returnedRoomDetails.Count());
        }

        [Fact]
        public void GetRoomDetailById_ExistingId_ReturnsOkResult_WithRoomDetail()
        {
            var mockRoomDetails = RoomDetailMockData.GetMockRoomDetails();
            var mockRoomDetailRepo = new Mock<IRoomDetail>();
            mockRoomDetailRepo.Setup(repo => repo.GetRoomDetail(It.IsAny<int>()))
                              .Returns<int>(id => mockRoomDetails.FirstOrDefault(r => r.RoomId == id));

            var roomController = new RoomController(mockRoomDetailRepo.Object);

            var existingRoomId = 1;
            var result = roomController.GetRoomDetailById(existingRoomId);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedRoomDetail = Assert.IsAssignableFrom<RoomDetail>(okResult.Value);
            Assert.Equal(existingRoomId, returnedRoomDetail.RoomId);
        }

        [Fact]
        public void AddRoom_ValidData_ReturnsCreatedAtActionResult_WithNewRoomDetail()
        {
            var newRoomDetail = new RoomDetail
            {
                RoomId = 3,
                RoomName = "Meeting Room C",
                RoomCapacity = 12,
                RoomLocation = "3rd Floor",
                ImageData = "base64image",
                Amenities = "Whiteboard, Projector"
            };

            var mockRoomDetailRepo = new Mock<IRoomDetail>();
            mockRoomDetailRepo.Setup(repo => repo.AddRoom(It.IsAny<RoomDetail>())).Returns(newRoomDetail);

            var roomController = new RoomController(mockRoomDetailRepo.Object);

            var result = roomController.AddRoom(newRoomDetail);

            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var returnedRoomDetail = Assert.IsAssignableFrom<RoomDetail>(createdAtActionResult.Value);
            Assert.Equal(newRoomDetail.RoomId, returnedRoomDetail.RoomId);
        }

        [Fact]
        public void UpdateRoomDetail_ExistingId_ValidData_ReturnsOkResult_WithUpdatedRoomDetail()
        {
            var existingRoomId = 2;
            var updatedRoomDetail = new RoomDetail
            {
                RoomId = existingRoomId,
                RoomName = "Updated Room",
                RoomCapacity = 15,
                RoomLocation = "Updated Location",
                ImageData = "base64image",
                Amenities = "Updated Amenities"
            };

            var mockRoomDetailRepo = new Mock<IRoomDetail>();
            mockRoomDetailRepo.Setup(repo => repo.UpdateRoomDetail(It.IsAny<RoomDetail>(), It.IsAny<int>())).Returns(updatedRoomDetail);

            var roomController = new RoomController(mockRoomDetailRepo.Object);

            var result = roomController.UpdateRoomDetail(existingRoomId, updatedRoomDetail);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedRoomDetail = Assert.IsAssignableFrom<RoomDetail>(okResult.Value);
            Assert.Equal(existingRoomId, returnedRoomDetail.RoomId);
        }

        [Fact]
        public void DeleteRoom_ExistingId_ReturnsOkResult_WithDeletedRoomDetail()
        {
            var mockRoomDetails = RoomDetailMockData.GetMockRoomDetails();
            var mockRoomDetailRepo = new Mock<IRoomDetail>();
            mockRoomDetailRepo.Setup(repo => repo.DeleteRoom(It.IsAny<int>()))
                              .Returns<int>(id =>
                              {
                                  var deletedRoomDetail = mockRoomDetails.FirstOrDefault(r => r.RoomId == id);
                                  if (deletedRoomDetail != null)
                                  {
                                      mockRoomDetails.Remove(deletedRoomDetail);
                                  }
                                  return deletedRoomDetail;
                              });

            var roomController = new RoomController(mockRoomDetailRepo.Object);

            var existingRoomId = 1;
            var result = roomController.DeleteRoom(existingRoomId);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var deletedRoomDetail = Assert.IsAssignableFrom<RoomDetail>(okResult.Value);
            Assert.Equal(existingRoomId, deletedRoomDetail.RoomId);
            Assert.DoesNotContain(mockRoomDetails, r => r.RoomId == existingRoomId);
        }
    }
}
