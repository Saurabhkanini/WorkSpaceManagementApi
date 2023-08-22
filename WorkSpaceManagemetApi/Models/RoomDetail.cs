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
        public string? RoomLocation { get; set; }    
        public string? ImageData { get; set; }

        [Column(TypeName = "nvarchar(max)")] // Use nvarchar(max) for JSON storage in SQL Server
        public string? Amenities { get; set; }
    }
}
