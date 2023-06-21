using System.ComponentModel.DataAnnotations;

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
        
        public string? Amenities { get; set; }   

    }
}
