using DevFullstackGuia.Models;
using Microsoft.EntityFrameworkCore;

namespace DevFullstackGuia.DAO
{
    public class AppDbContext : DbContext
    {
        public DbSet<Cliente> User { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}