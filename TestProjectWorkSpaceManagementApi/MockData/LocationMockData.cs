using System.Collections.Generic;
using WorkSpaceManagemetApi.Models;

namespace TestProjectWorkSpaceManagementApi
{
    internal class LocationMockData
    {
        public static List<Location> GetAllLocationsMockData()
        {
            return new List<Location>
            {
                new Location
                {
                    Location_Id = 1,
                    FloorNumberOrBuildingName = "Building A",
                    StreetAddress = "123 Main St",
                    City = "Akot",
                    State = "MAHARASHTRA",
                    Pincode = 12345,
                    Country = "India",
                    ImageData ="image",
                    NumberOfConferenceRooms =10,
                    NumberOfDesk =144
    },
                new Location
                {
                    Location_Id = 2,
                    FloorNumberOrBuildingName = "Building B",
                    StreetAddress = "456 Elm St",
                    City = "Chennai",
                    State = "TamilNadu",
                    Pincode = 67890,
                    Country = "India",
                    ImageData ="image",
                    NumberOfConferenceRooms =10,
                    NumberOfDesk =144
                }
            };
        }
    }
}
