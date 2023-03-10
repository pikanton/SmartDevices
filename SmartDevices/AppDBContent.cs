using Microsoft.EntityFrameworkCore;
using SmartDevices.Models;

namespace SmartDevices
{
    public class AppDBContext : DbContext
    {
        public AppDBContext()
        {

        }
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        public DbSet<Device> Device { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<House> House { get; set; }
        public DbSet<User> User { get; set; }
    }
}
