using System.ComponentModel.DataAnnotations;

namespace WorkSpaceManagemetApi.Models
{
    public class Notification
    {
        [Key]
        public int NotificationId { get; set; }
        public string NotificationSubject { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
    }
}
