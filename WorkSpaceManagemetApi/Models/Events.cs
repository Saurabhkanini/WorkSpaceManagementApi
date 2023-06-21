using System.ComponentModel.DataAnnotations;

namespace WorkSpaceManagemetApi.Models
{
    public class Events
    {
        [Key]
        public int EventId { get; set; }
        public byte[] image { get; set; }
        public string? EventTitle { get; set; }
        public string? Location { get; set; }

        public DateTime date { get; set; }
        public DateTime time { get; set; }
    }
}
