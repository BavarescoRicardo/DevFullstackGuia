using DevFullstackGuia.Models;
using Microsoft.EntityFrameworkCore;

namespace DevFullstackGuia.DAO
{
    public class AppDbContext : DbContext
    {
        public DbSet<Cliente> Cliente{ get; set; } // DbSet for Suite
        public DbSet<Suite> Suite { get; set; } // DbSet for Suite
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Optional: Configure the primary key explicitly (not required if using conventions)
            modelBuilder.Entity<Suite>()
                .HasKey(s => s.Id); // Explicitly define the primary key
        }
    }
}