using Microsoft.AspNetCore.Mvc;
using Moq;
using WorkSpaceManagemetApi.Controllers;
using WorkSpaceManagemetApi.Models;
using WorkSpaceManagemetApi.Repository;
using WorkSpaceManagemetApi.MockData;

namespace TestProjectWorkSpaceManagementApi
{
    public class RoomBookingControllerTests
    {
        [Fact]
        public void GetAllRbookings_ReturnsAllRoomBookings()
        {
            var mockRoomBookings = RoomBookingMockData.GetMockRoomBookings();
            var mockRoomBookingRepo = new Mock<IRoomBooking>();
            mockRoomBookingRepo.Setup(repo => repo.GetAllRbooking()).Returns(mockRoomBookings);
            var roomBookingController = new RoomBookingController(mockRoomBookingRepo.Object);

            var result = roomBookingController.GetAllRbookings();

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedRoomBookings = Assert.IsAssignableFrom<IEnumerable<RoomBooking>>(okResult.Value);
            Assert.Equal(mockRoomBookings.Count, returnedRoomBookings.Count());
        }

        [Fact]
        public void GetRbookingById_ExistingId_ReturnsOkResult_WithRoomBooking()
        {
            var mockRoomBookings = RoomBookingMockData.GetMockRoomBookings();
            var mockRoomBookingRepo = new Mock<IRoomBooking>();
            mockRoomBookingRepo.Setup(repo => repo.GetRbooking(It.IsAny<int>()))
                              .Returns<int>(id => mockRoomBookings.FirstOrDefault(rb => rb.BookingId == id));

            var roomBookingController = new RoomBookingController(mockRoomBookingRepo.Object);

            var existingBookingId = 1;
            var result = roomBookingController.GetRbookingById(existingBookingId);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedRoomBooking = Assert.IsAssignableFrom<RoomBooking>(okResult.Value);
            Assert.Equal(existingBookingId, returnedRoomBooking.BookingId);
        }

        [Fact]
        public void BookRoom_ValidData_ReturnsCreatedAtActionResult_WithNewRoomBooking()
        {
            var newRoomBooking = new RoomBooking
            {
                BookingId = 3,
                MeetingTitle = "New Meeting",
                NumberOfParticipants = 10,
                startTime = DateTime.Now.AddDays(2),
                endTime = DateTime.Now.AddDays(2).AddHours(2),
                EmployeeId = 1,
                roomId = 2
            };

            var mockRoomBookingRepo = new Mock<IRoomBooking>();
            mockRoomBookingRepo.Setup(repo => repo.BookRoom(It.IsAny<RoomBooking>())).Returns(newRoomBooking);

            var roomBookingController = new RoomBookingController(mockRoomBookingRepo.Object);

            var result = roomBookingController.BookRoom(newRoomBooking);

            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var returnedRoomBooking = Assert.IsAssignableFrom<RoomBooking>(createdAtActionResult.Value);
            Assert.Equal(newRoomBooking.BookingId, returnedRoomBooking.BookingId);
        }

        [Fact]
        public void UpdateRbookingDetail_ExistingId_ValidData_ReturnsOkResult_WithUpdatedRoomBooking()
        {
            var existingBookingId = 2;
            var updatedRoomBooking = new RoomBooking
            {
                BookingId = existingBookingId,
                MeetingTitle = "Updated Meeting",
                NumberOfParticipants = 15,
                startTime = DateTime.Now.AddDays(3),
                endTime = DateTime.Now.AddDays(3).AddHours(3),
                EmployeeId = 2,
                roomId = 3
            };

            var mockRoomBookingRepo = new Mock<IRoomBooking>();
            mockRoomBookingRepo.Setup(repo => repo.UpdateRbookingDetail(It.IsAny<RoomBooking>(), It.IsAny<int>())).Returns(updatedRoomBooking);

            var roomBookingController = new RoomBookingController(mockRoomBookingRepo.Object);

            var result = roomBookingController.UpdateRbookingDetail(existingBookingId, updatedRoomBooking);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedRoomBooking = Assert.IsAssignableFrom<RoomBooking>(okResult.Value);
            Assert.Equal(existingBookingId, returnedRoomBooking.BookingId);
        }

        [Fact]
        public void DeleteBooking_ExistingId_ReturnsOkResult_WithDeletedRoomBooking()
        {
            var mockRoomBookings = RoomBookingMockData.GetMockRoomBookings();
            var mockRoomBookingRepo = new Mock<IRoomBooking>();
            mockRoomBookingRepo.Setup(repo => repo.DeleteBooking(It.IsAny<int>()))
                              .Returns<int>(id =>
                              {
                                  var deletedRoomBooking = mockRoomBookings.FirstOrDefault(rb => rb.BookingId == id);
                                  if (deletedRoomBooking != null)
                                  {
                                      mockRoomBookings.Remove(deletedRoomBooking);
                                  }
                                  return deletedRoomBooking;
                              });

            var roomBookingController = new RoomBookingController(mockRoomBookingRepo.Object);

            var existingBookingId = 1;
            var result = roomBookingController.DeleteBooking(existingBookingId);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var deletedRoomBooking = Assert.IsAssignableFrom<RoomBooking>(okResult.Value);
            Assert.Equal(existingBookingId, deletedRoomBooking.BookingId);
            Assert.DoesNotContain(mockRoomBookings, rb => rb.BookingId == existingBookingId);
        }
    }
}
