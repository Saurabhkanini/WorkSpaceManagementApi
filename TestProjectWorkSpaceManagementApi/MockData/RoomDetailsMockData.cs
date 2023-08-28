using System.Collections.Generic;
using WorkSpaceManagemetApi.Models;

namespace TestProjectWorkSpaceManagementApi.MockData
{
    public static class RoomDetailMockData
    {
        public static List<RoomDetail> GetMockRoomDetails()
        {
            return new List<RoomDetail>
            {
                new RoomDetail
                {
                    RoomId = 1,
                    RoomName = "Conference Room A",
                    RoomCapacity = 20,
                    RoomLocation = "5th Floor",
                    ImageData = "base64image",
                    Amenities = "Projector, Whiteboard, Video Conferencing"
                },
                new RoomDetail
                {
                    RoomId = 2,
                    RoomName = "Meeting Room B",
                    RoomCapacity = 10,
                    RoomLocation = "2nd Floor",
                    ImageData = "base64image",
                    Amenities = "Whiteboard, Speakerphone"
                }
            };
        }
    }
}
