using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkSpaceManagemetApi.Models
{
    public class Notification
    {
        [Key]
        public int NotificationId { get; set; }
        public string NotificationSubject { get; set; }
        public string Description { get; set; }
        [ForeignKey("Location")]
        public int LocationId { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public Location? location { get; set; } 
    }
}
