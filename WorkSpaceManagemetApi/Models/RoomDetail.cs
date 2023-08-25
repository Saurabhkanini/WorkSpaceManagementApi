using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkSpaceManagemetApi.Models
{
    public class RoomDetail
    {
        [Key]
        public int RoomId { get; set; }
        public string ?RoomName { get; set; }
        public int ?RoomCapacity { get; set; }  
        [ForeignKey("Location")]
        public int LocationId { get; set; }    
        public string? ImageData { get; set; }

        [Column(TypeName = "nvarchar(max)")] 
        public string? Amenities { get; set; }
        public Location ?location { get; set; } 
    }
}
