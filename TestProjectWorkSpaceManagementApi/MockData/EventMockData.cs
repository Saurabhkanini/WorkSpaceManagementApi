using System;
using System.Collections.Generic;
using WorkSpaceManagemetApi.Models;

namespace TestProjectWorkSpaceManagementApi
{
    internal class EventMockData
    {
        public static List<Events> GetAllEventsMockData()
        {
            return new List<Events>
            {
                new Events
                {
                    EventId = 1,
                    imageData = "image",
                    EventTitle = "Sample Event",
                    EventDescription = "This is a sample event description.",
                    LocationId = 1,
                    startTime = DateTime.Now,
                    endTime = DateTime.Now.AddHours(3),
                   
    },
                new Events
                {
                   EventId = 2,
                    imageData = "image",
                    EventTitle = "Another Event",
                    EventDescription = "This is another event description.",
                    LocationId = 2,
                    startTime = DateTime.Now.AddHours(4),
                    endTime = DateTime.Now.AddHours(7),
                }
            };
        }
    }
}
