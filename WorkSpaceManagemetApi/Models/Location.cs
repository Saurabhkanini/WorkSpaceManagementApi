using System.ComponentModel.DataAnnotations;

namespace WorkSpaceManagemetApi.Models
{
    public class Location
    {
        [Key]
        public int Location_Id { get; set; }
        public string FloorNumberOrBuildingName { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Pincode { get; set; }
        public string Country { get; set; }
        public byte[] Image { get; set; }
        public int NumberOfConferenceRooms { get; set; }
        public int NumberOfDesk { get; set; }

    }
}
