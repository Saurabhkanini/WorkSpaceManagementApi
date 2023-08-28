using Microsoft.AspNetCore.Mvc;
using Moq;
using WorkSpaceManagemetApi.Controllers;
using WorkSpaceManagemetApi.Models;
using WorkSpaceManagemetApi.Repository;

namespace TestProjectWorkSpaceManagementApi
{
    public class NotificationControllerTests
    {
        [Fact]
        public void GetAllNotifications_ReturnsAllNotifications()
        {
            var mockNotifications = NotificationMockData.GetAllNotificationsMockData();
            var mockNotificationRepo = new Mock<INotification>();
            mockNotificationRepo.Setup(repo => repo.GetAllNotification()).Returns(mockNotifications);
            var notificationController = new NotificationController(mockNotificationRepo.Object);

            var result = notificationController.GetAllNotifications();

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedNotifications = Assert.IsAssignableFrom<IEnumerable<Notification>>(okResult.Value);
            Assert.Equal(mockNotifications.Count, returnedNotifications.Count());
        }

        [Fact]
        public void GetNotificationById_ExistingId_ReturnsOkResult_WithNotification()
        {
            var mockNotifications = NotificationMockData.GetAllNotificationsMockData();
            var mockNotificationRepo = new Mock<INotification>();
            mockNotificationRepo.Setup(repo => repo.GetNotification(It.IsAny<int>()))
                                .Returns<int>(id => mockNotifications.FirstOrDefault(n => n.NotificationId == id));

            var notificationController = new NotificationController(mockNotificationRepo.Object);

            var existingNotificationId = 1;
            var result = notificationController.GetNotificationById(existingNotificationId);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedNotification = Assert.IsAssignableFrom<Notification>(okResult.Value);
            Assert.Equal(existingNotificationId, returnedNotification.NotificationId);
        }

        [Fact]
        public void AddNotification_ValidData_ReturnsCreatedAtActionResult_WithNewNotification()
        {
            var newNotification = new Notification
            {
                NotificationId = 3,
                NotificationSubject = "New Notification",
                Description = "New notification description",
                Date = DateTime.Now,
                Time = new DateTime(2023, 8, 1, 10, 0, 0)
            };

            var mockNotificationRepo = new Mock<INotification>();
            mockNotificationRepo.Setup(repo => repo.AddNotification(It.IsAny<Notification>())).Returns(newNotification);

            var notificationController = new NotificationController(mockNotificationRepo.Object);

            var result = notificationController.AddNotification(newNotification);

            var okResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var returnedNotification = Assert.IsAssignableFrom<Notification>(okResult.Value);
            Assert.Equal(newNotification.NotificationId, returnedNotification.NotificationId);
        }

        [Fact]
        public void UpdateNotification_ExistingId_ValidData_ReturnsOkResult_WithUpdatedNotification()
        {
            var existingNotificationId = 2;
            var updatedNotification = new Notification
            {
                NotificationId = existingNotificationId,
                NotificationSubject = "Updated Notification",
                Description = "Updated notification description",
                Date = DateTime.Now.AddDays(1),
                Time = new DateTime(2023, 8, 1, 10, 0, 0)

            };

            var mockNotificationRepo = new Mock<INotification>();
            mockNotificationRepo.Setup(repo => repo.UpdateNotification(It.IsAny<Notification>(), It.IsAny<int>())).Returns(updatedNotification);

            var notificationController = new NotificationController(mockNotificationRepo.Object);

            var result = notificationController.UpdateNotification(existingNotificationId, updatedNotification);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedNotification = Assert.IsAssignableFrom<Notification>(okResult.Value);
            Assert.Equal(existingNotificationId, returnedNotification.NotificationId);
        }

        [Fact]
        public void DeleteNotification_ExistingId_ReturnsOkResult_WithDeletedNotification()
        {
            var mockNotifications = NotificationMockData.GetAllNotificationsMockData();
            var mockNotificationRepo = new Mock<INotification>();
            mockNotificationRepo.Setup(repo => repo.DeleteNotification(It.IsAny<int>()))
                                .Returns<int>(id =>
                                {
                                    var deletedNotification = mockNotifications.FirstOrDefault(n => n.NotificationId == id);
                                    if (deletedNotification != null)
                                    {
                                        mockNotifications.Remove(deletedNotification);
                                    }
                                    return deletedNotification;
                                });

            var notificationController = new NotificationController(mockNotificationRepo.Object);

            var existingNotificationId = 1;

            var result = notificationController.DeleteNotification(existingNotificationId);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var deletedNotification = Assert.IsAssignableFrom<Notification>(okResult.Value);
            Assert.Equal(existingNotificationId, deletedNotification.NotificationId);
            Assert.DoesNotContain(mockNotifications, n => n.NotificationId == existingNotificationId);
        }
    }
}
