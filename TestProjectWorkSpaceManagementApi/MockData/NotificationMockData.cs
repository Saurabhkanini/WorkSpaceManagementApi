using System;
using System.Collections.Generic;
using WorkSpaceManagemetApi.Models;

namespace TestProjectWorkSpaceManagementApi
{
    internal class NotificationMockData
    {
        public static List<Notification> GetAllNotificationsMockData()
        {
            return new List<Notification>
            {
                new Notification
                {
                    NotificationId = 1,
                    NotificationSubject = "Subject 1",
                    Description = "Description 1",
                    Date = new DateTime(2023, 8, 1),
                    Time = new DateTime(2023, 8, 1, 10, 0, 0)
                },
                new Notification
                {
                    NotificationId = 2,
                    NotificationSubject = "Subject 2",
                    Description = "Description 2",
                    Date = new DateTime(2023, 8, 2),
                    Time = new DateTime(2023, 8, 2, 15, 30, 0)
                }
            };
        }
    }
}
