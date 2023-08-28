using Microsoft.AspNetCore.Mvc;
using Moq;
using WorkSpaceManagemetApi.Controllers;
using WorkSpaceManagemetApi.Models;
using WorkSpaceManagemetApi.Repository;
using TestProjectWorkSpaceManagementApi.MockData;

namespace TestProjectWorkSpaceManagementApi
{
    public class DeskBookingControllerTests
    {
        [Fact]
        public void GetAllDbookings_ReturnsAllBookings()
        {
            var mockBookings = DeskBookingMockData.GetAllDeskBookingsMockData();
            var mockBookingRepo = new Mock<IDeskBooking>();
            mockBookingRepo.Setup(repo => repo.GetAllDbooking()).Returns(mockBookings);
            var bookingController = new DeskBookingController(mockBookingRepo.Object);

            var result = bookingController.GetAllDbookings();

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedBookings = Assert.IsAssignableFrom<IEnumerable<DeskBooking>>(okResult.Value);
            Assert.Equal(mockBookings.Count, returnedBookings.Count());
        }

        [Fact]
        public void GetDbookingById_ExistingId_ReturnsOkResult_WithBooking()
        {
            var mockBookings = DeskBookingMockData.GetAllDeskBookingsMockData();
            var mockBookingRepo = new Mock<IDeskBooking>();
            mockBookingRepo.Setup(repo => repo.GetDbooking(It.IsAny<int>()))
                            .Returns<int>(id => mockBookings.FirstOrDefault(b => b.BookingId == id));

            var bookingController = new DeskBookingController(mockBookingRepo.Object);

            var existingBookingId = 1;
            var result = bookingController.GetDbookingById(existingBookingId);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedBooking = Assert.IsAssignableFrom<DeskBooking>(okResult.Value);
            Assert.Equal(existingBookingId, returnedBooking.BookingId);
        }

        [Fact]
        public void BookDesk_ValidData_ReturnsCreatedAtActionResult_WithNewBooking()
        {
            var newBooking = new DeskBooking
            {
                BookingId = 3,
                Location = "New York",
                BookingDate = DateTime.Now.Date.AddDays(2),
                BookingTime = DateTime.Now,
                EmployeeName = "John Doe",
                EmployeeId = 1
            };

            var mockBookingRepo = new Mock<IDeskBooking>();
            mockBookingRepo.Setup(repo => repo.BookDesk(It.IsAny<DeskBooking>())).Returns(newBooking);

            var bookingController = new DeskBookingController(mockBookingRepo.Object);

            var result = bookingController.BookDesk(newBooking);

            var okResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var returnedBooking = Assert.IsAssignableFrom<DeskBooking>(okResult.Value);
            Assert.Equal(newBooking.BookingId, returnedBooking.BookingId);
        }

        [Fact]
        public void UpdateDbookingDetail_ExistingId_ValidData_ReturnsOkResult_WithUpdatedBooking()
        {
            var existingBookingId = 2;
            var updatedBooking = new DeskBooking
            {
                BookingId = existingBookingId,
                Location = "Updated Location",
                BookingDate = DateTime.Now.Date.AddDays(3),
                BookingTime = DateTime.Now,
                EmployeeName = "Jane Smith",
                EmployeeId = 2
            };

            var mockBookingRepo = new Mock<IDeskBooking>();
            mockBookingRepo.Setup(repo => repo.UpdateDbookingDetail(It.IsAny<DeskBooking>(), It.IsAny<int>())).Returns(updatedBooking);

            var bookingController = new DeskBookingController(mockBookingRepo.Object);

            var result = bookingController.UpdateDbookingDetail(existingBookingId, updatedBooking);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedBooking = Assert.IsAssignableFrom<DeskBooking>(okResult.Value);
            Assert.Equal(existingBookingId, returnedBooking.BookingId);
        }

        [Fact]
        public void DeleteBooking_ExistingId_ReturnsOkResult_WithDeletedBooking()
        {
            var mockBookings = DeskBookingMockData.GetAllDeskBookingsMockData();
            var mockBookingRepo = new Mock<IDeskBooking>();
            mockBookingRepo.Setup(repo => repo.DeleteBooking(It.IsAny<int>()))
                            .Returns<int>(id =>
                            {
                                var deletedBooking = mockBookings.FirstOrDefault(b => b.BookingId == id);
                                if (deletedBooking != null)
                                {
                                    mockBookings.Remove(deletedBooking);
                                }
                                return deletedBooking;
                            });

            var bookingController = new DeskBookingController(mockBookingRepo.Object);

            var existingBookingId = 1;

            var result = bookingController.DeleteBooking(existingBookingId);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var deletedBooking = Assert.IsAssignableFrom<DeskBooking>(okResult.Value);
            Assert.Equal(existingBookingId, deletedBooking.BookingId);
            Assert.DoesNotContain(mockBookings, b => b.BookingId == existingBookingId);
        }
    }
}
