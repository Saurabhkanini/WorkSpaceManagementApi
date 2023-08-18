using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace WorkSpaceManagemetApi.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        [ForeignKey("Location")]
        public int LocationId { get; set; }
        [ForeignKey("Department")]
        public int DepId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string AddPassword { get; set; }
        public string Title { get; set; }
        public byte[] UserImage { get; set; } 
        public Department? Department { get; set; }
        public Location ?location { get; set; } 
    }
}
