using System.ComponentModel.DataAnnotations;

namespace WorkSpaceManagemetApi.Models
{
    public class AdminRegister
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
