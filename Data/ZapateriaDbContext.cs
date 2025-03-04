using Microsoft.EntityFrameworkCore;
using Zapateria.Models;

namespace Zapateria.Data
{
    public class ZapateriaDbContext : DbContext
    {
        public ZapateriaDbContext(DbContextOptions<ZapateriaDbContext> options) : base(options){}
        public DbSet<Zapato> Zapatos { get; set; }
        public DbSet<Tipo> Tipos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Zapato>().ToTable("Zapato");
            modelBuilder.Entity<Tipo>().ToTable("Tipo");

            modelBuilder.Entity<Zapato>()
                .HasKey(z => z.Id);

            modelBuilder.Entity<Zapato>()
                .Property(z => z.Marca)
                .HasMaxLength(20);

            modelBuilder.Entity<Zapato>()
                .Property(z => z.Modelo)
                .HasMaxLength(50);

            modelBuilder.Entity<Zapato>()
                .Property(z => z.Color)
                .HasMaxLength(20);

            modelBuilder.Entity<Tipo>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<Tipo>()
                .Property(t => t.Nombre)
                .HasMaxLength(50);
        }
    }
}
