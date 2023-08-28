using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using WorkSpaceManagemetApi.Controllers;
using WorkSpaceManagemetApi.Models;
using WorkSpaceManagemetApi.Repository;

namespace TestProjectWorkSpaceManagementApi
{
    public class EventControllerTest
    {
        [Fact]
        public void GetAllEvents_ReturnsAllEvents()
        {
            var mockEvents = EventMockData.GetAllEventsMockData();
            var mockEventRepo = new Mock<IEvent>();
            mockEventRepo.Setup(repo => repo.GetAllEvents()).Returns(mockEvents);
            var eventController = new EventController(mockEventRepo.Object);

            var result = eventController.GetAllEvents();

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedEvents = Assert.IsAssignableFrom<IEnumerable<Events>>(okResult.Value);
            Assert.Equal(mockEvents.Count, returnedEvents.Count());
        }

        [Fact]
        public void GetEventById_ExistingId_ReturnsOkResult_WithEvent()
        {
            var mockEvents = EventMockData.GetAllEventsMockData();
            var mockEventRepo = new Mock<IEvent>();
            mockEventRepo.Setup(repo => repo.GetEvent(It.IsAny<int>()))
                         .Returns<int>(id => mockEvents.FirstOrDefault(e => e.EventId == id));

            var eventController = new EventController(mockEventRepo.Object);

            var existingEventId = 1;
            var result = eventController.GetEventById(existingEventId);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedEvent = Assert.IsAssignableFrom<Events>(okResult.Value);
            Assert.Equal(existingEventId, returnedEvent.EventId);
        }

        [Fact]
        public void AddEvent_ValidData_ReturnsCreatedAtAction()
        {
            var newEvent = new Events
            {
                EventId = 3,
                EventTitle = "New Event",
                EventDescription = "This is a new event description.",
                LocationId = 1,
                startTime = DateTime.Now,
                endTime = DateTime.Now.AddHours(2),
                imageData = "image"
            };

            var mockEventRepo = new Mock<IEvent>();
            mockEventRepo.Setup(repo => repo.AddEvent(It.IsAny<Events>())).Returns(newEvent);

            var eventController = new EventController(mockEventRepo.Object);

            var result = eventController.AddEvent(newEvent);

            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var returnedEvent = Assert.IsAssignableFrom<Events>(createdAtActionResult.Value);
            Assert.Equal(newEvent.EventId, returnedEvent.EventId);
        }

        [Fact]
        public void UpdateEvent_ExistingId_ValidData_ReturnsOkResult_WithUpdatedEvent()
        {
            var existingEventId = 2;
            var updatedEvent = new Events
            {
                EventId = existingEventId,
                EventTitle = "Updated Event",
                EventDescription = "This is an updated event description.",
                LocationId = 2,
                startTime = DateTime.Now,
                endTime = DateTime.Now.AddHours(3),
                imageData = "updated image"
            };

            var mockEventRepo = new Mock<IEvent>();
            mockEventRepo.Setup(repo => repo.UpdateEvent(It.IsAny<Events>(), It.IsAny<int>())).Returns(updatedEvent);

            var eventController = new EventController(mockEventRepo.Object);

            var result = eventController.UpdateEvent(existingEventId, updatedEvent);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedEvent = Assert.IsAssignableFrom<Events>(okResult.Value);
            Assert.Equal(existingEventId, returnedEvent.EventId);
        }

        [Fact]
        public void DeleteEvent_ExistingId_ReturnsOkResult_WithDeletedEvent()
        {
            var mockEvents = EventMockData.GetAllEventsMockData();
            var mockEventRepo = new Mock<IEvent>();
            mockEventRepo.Setup(repo => repo.DeleteEvent(It.IsAny<int>()))
                         .Returns<int>(id =>
                         {
                             var deletedEvent = mockEvents.FirstOrDefault(e => e.EventId == id);
                             if (deletedEvent != null)
                             {
                                 mockEvents.Remove(deletedEvent);
                             }
                             return deletedEvent;
                         });

            var eventController = new EventController(mockEventRepo.Object);

            var existingEventId = 1;

            var result = eventController.DeleteEvent(existingEventId);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var deletedEvent = Assert.IsAssignableFrom<Events>(okResult.Value);
            Assert.Equal(existingEventId, deletedEvent.EventId);
            Assert.DoesNotContain(mockEvents, e => e.EventId == existingEventId);
        }
    }
}