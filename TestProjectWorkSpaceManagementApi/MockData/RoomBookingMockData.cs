using System;
using System.Collections.Generic;
using WorkSpaceManagemetApi.Models;

namespace WorkSpaceManagemetApi.MockData
{
    public static class RoomBookingMockData
    {
        public static List<RoomBooking> GetMockRoomBookings()
        {
            return new List<RoomBooking>
            {
                new RoomBooking
                {
                    BookingId = 1,
                    MeetingTitle = "Team Meeting",
                    NumberOfParticipants = 10,
                    startTime = DateTime.Now.AddHours(1),
                    endTime = DateTime.Now.AddHours(2),
                    roomId = 101
                },
                new RoomBooking
                {
                    BookingId = 2,
                    MeetingTitle = "Client Presentation",
                    NumberOfParticipants = 5,
                    startTime = DateTime.Now.AddHours(3),
                    endTime = DateTime.Now.AddHours(4),
                    roomId = 102
                }
            };
        }
    }
}
