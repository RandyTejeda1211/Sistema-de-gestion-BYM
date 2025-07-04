using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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
        public DbSet<ServiceProvided> serviceProvided { get; set; }
        public DbSet<Cite> cites { get; set; }
        public DbSet<ServicePRegistered> servicePRegistereds { get; set; }
        public DbSet<Bills> bills { get; set; }

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
            modelBuilder.Entity<ServiceProvided>(entity =>
            {
                entity.ToTable("servicios");
                entity.HasKey(x => x.idServicios);
                entity.Property(e => e.caracteristica).HasMaxLength(100);
            });
            modelBuilder.Entity<Cite>( entity =>
            {
                entity.ToTable("cita");
                entity.HasKey(x => x.idCita);
                entity.HasOne(c => c.Client)
                    .WithMany(cl => cl.Cites)
                    .HasForeignKey(c => c.idCliente)
                    .OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<ServicePRegistered>(entity =>
            {
                entity.ToTable("servicio_registrado");
                entity.HasKey(x => x.idServicioRegistrado);

                entity.HasOne(e => e.Cite)
                    .WithMany(c => c.servicePRegistereds)
                    .HasForeignKey(c => c.idCita)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.ServiceP)
                    .WithMany(s => s.servicePRegistereds)
                    .HasForeignKey(e => e.idServicio)
                    .OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<Bills>(entity =>
            {
                entity.ToTable("facturas");
                entity.HasKey(x => x.idfacturas);
                entity.Property(x => x.serial)
                    .HasMaxLength(50)
                    .IsRequired();

                entity.HasOne(c => c.ServicePRegistered)
                    .WithMany(c => c.bills)
                    .HasForeignKey(c => c.idServicioRegistrado)
                    .OnDelete(DeleteBehavior.Cascade);
                    
            });
        }
        
    }
}
