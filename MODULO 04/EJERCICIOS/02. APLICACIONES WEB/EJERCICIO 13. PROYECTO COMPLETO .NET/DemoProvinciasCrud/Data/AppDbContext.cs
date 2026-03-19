using DemoProvinciasCrud.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoProvinciasCrud.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Provincia> Provincias => Set<Provincia>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Provincia>(entity =>
        {
            entity.ToTable("provincias");
            entity.HasKey(p => p.IdProvincia);

            entity.Property(p => p.IdProvincia).HasColumnName("idprovincia");
            entity.Property(p => p.Nombre).HasColumnName("provincia");
        });
    }
}
