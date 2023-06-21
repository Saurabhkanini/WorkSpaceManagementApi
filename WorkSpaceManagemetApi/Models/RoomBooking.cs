using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkSpaceManagemetApi.Models
{
    public class RoomBooking
    {
        [Key]
        public int BookingId { get; set; }
        public string? RoomName { get; set; }
        public int? RoomCapacity { get; set; }
        public string? RoomLocation { get; set; }
        public string? ImageData { get; set; }
        public string? Amenities { get; set; }
        public string MeetingTitle { get; set; }
        public int NumberOfParticipants { get; set; }
        public string BookedFor { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime BookingTime { get; set; }
        public string EmployeeName { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }


    }
}
