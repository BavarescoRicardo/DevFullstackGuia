using DevFullstackGuia.Models;
using Microsoft.EntityFrameworkCore;

namespace DevFullstackGuia.DAO
{
    public class AppDbContext : DbContext
    {
        public DbSet<Motel> Motel { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Suite> Suite { get; set; }
        public DbSet<Reserva> Reserva { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Adicionar chaves para o mapeamento de cada entidade
            modelBuilder.Entity<Motel>()
                .HasKey(m => m.Id);

            modelBuilder.Entity<Cliente>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Suite>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<Reserva>()
                .HasKey(s => s.Id);
        }
    }
}