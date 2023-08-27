using System;
using System.Collections.Generic;
using WorkSpaceManagemetApi.Models;

namespace TestProjectWorkSpaceManagementApi.MockData
{
    public static class DeskBookingMockData
    {
        public static List<DeskBooking> GetAllDeskBookingsMockData()
        {
            return new List<DeskBooking>
            {
                new DeskBooking
                {
                    BookingId = 1,
                    Location = "New York",
                    BookingDate = DateTime.Now.Date.AddDays(1),
                    BookingTime = DateTime.Now,
                    EmployeeName = "John Doe",
                    EmployeeId = 1
                },
                new DeskBooking
                {
                    BookingId = 2,
                    Location = "Los Pune",
                    BookingDate = DateTime.Now.Date.AddDays(2),
                    BookingTime = DateTime.Now,
                    EmployeeName = "Jane Smith",
                    EmployeeId = 2
                },
                 new DeskBooking
                {
                    BookingId = 3,
                    Location = "City Of Heaven Pune",
                    BookingDate = DateTime.Now.Date.AddDays(3),
                    BookingTime = DateTime.Now,
                    EmployeeName = "Jane Smith",
                    EmployeeId = 3
                }
            };
        }
    }
}
