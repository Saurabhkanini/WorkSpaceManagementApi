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
        public string ImageData { get; set; }
        public int NumberOfConferenceRooms { get; set; }
        public int NumberOfDesk { get; set; }
        public ICollection<RoomDetail>? RoomDetail { get; set; }
        public ICollection<Employee>? Employee { get; set; }
        public ICollection<Events> ? events { get; set; }   
        public ICollection<Notification>? Notification { get; set; }    

    }
}
