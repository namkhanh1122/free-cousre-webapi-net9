using Microsoft.EntityFrameworkCore;
using freecourse_api.Models;

namespace freecourse_api.Data
{   
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
    }
}