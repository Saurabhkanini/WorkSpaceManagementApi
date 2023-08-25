using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkSpaceManagemetApi.Models
{
    public class DeskBooking
    {
        [Key]
        public int BookingId { get; set; }
        public string Location { get; set; }
        public DateTime BookingDate { get; set; }   
        public DateTime BookingTime { get; set; }
        public string EmployeeName { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

    }
}
