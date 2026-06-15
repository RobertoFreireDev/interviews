using Microsoft.EntityFrameworkCore;
using WebApplication.Entities;

namespace WebApplication.EF
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Event> eventos { get; set; }
    }
}
