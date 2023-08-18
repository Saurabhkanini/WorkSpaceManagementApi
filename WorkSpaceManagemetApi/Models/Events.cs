using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkSpaceManagemetApi.Models
{
    public class Events
    {
        [Key]
        public int EventId { get; set; }
        public byte[] image { get; set; }
        public string? EventTitle { get; set; }
        [StringLength(200,MinimumLength =5)]
        public string EventDescription { get; set; }
        [ForeignKey("Location")]
        public int LocationId { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public Location? location { get; set; } 
    }
}
