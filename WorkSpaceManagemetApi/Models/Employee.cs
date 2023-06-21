using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace WorkSpaceManagemetApi.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string LocationName { get; set; }
        public string Department { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string AddPassword { get; set; }
        public string ConfirmPassword { get; set; }
        public byte[] UserImage { get; set; } 
    }
}
