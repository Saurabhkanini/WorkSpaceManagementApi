using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkSpaceManagemetApi.Models
{
    public class RoomBooking
    {
        [Key]
        public int BookingId { get; set; }
        public string MeetingTitle { get; set; }
        public int NumberOfParticipants { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public string EmployeeName { get; set; }
        [ForeignKey("RoomDetail")]
        public int roomId { get; set; }
        public Employee ?employee { get; set; } 
        public RoomDetail? RoomDetail { get; set; }


    }
}
