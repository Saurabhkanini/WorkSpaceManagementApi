using Microsoft.EntityFrameworkCore;
using WorkSpaceManagemetApi.Models;

namespace WorkSpaceManagemetApi.DataAccess
{
    public class WorkSpaceDbContext:DbContext
    {
        public WorkSpaceDbContext(DbContextOptions options) : base(options) { }
        public DbSet<DeskBooking> deskBookings { get; set; }
        public DbSet<RoomDetail> roomDetail { get; set; }
        public DbSet<RoomBooking> roomBooking { get; set; } 
        public DbSet<Employee> employees { get; set; }
        public DbSet<Events> events { get; set; }
        public DbSet<Location> location { get; set; }
        public DbSet<Notification> notifications { get; set; }

        
    }
}
