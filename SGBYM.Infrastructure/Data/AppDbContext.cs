using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SGBYM.Domain.Models;

namespace SGBYM.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Client> clients { get; set; }
        public DbSet<Administrator> administrators { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("cliente");
                entity.HasKey(x => x.IdCliente);
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Correo).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Telefono).IsRequired().HasMaxLength(20);
            });
            modelBuilder.Entity<Administrator>(entity =>
            {
                entity.ToTable("administrador");
                entity.HasKey(x => x.idAdmin);
                entity.Property(e => e.username).IsRequired().HasMaxLength(50);
                entity.Property(e => e.passwordHash)
                    .HasColumnName("password")
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(e => e.correo).IsRequired().HasMaxLength(100);
            });
        }
        
    }
}
