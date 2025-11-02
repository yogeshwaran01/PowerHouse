using Microsoft.EntityFrameworkCore;
using PowerHouse.Models;

namespace PowerHouse.Context
{
    public class PowerHouseDbContext(DbContextOptions<PowerHouseDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Activity> Activities{ get; set; }

        public DbSet<Log> Logs{ get; set; }
    }


}