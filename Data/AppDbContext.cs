using Microsoft.EntityFrameworkCore;
using CQRSMediatrDemo.Models;

namespace CQRSMediatrDemo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Add Students DbSet
        public DbSet<Student> Students { get; set; } = null!;

        // other DbSets...
    }
}

