using GLMS.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace GLMS.API.Data
{
    public class GLMSDbContext : DbContext
    {
        public GLMSDbContext(DbContextOptions<GLMSDbContext> options)
          : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<ServiceRequest> ServiceRequests { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ServiceRequest>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.USDAmount)
       .HasColumnType("decimal(18,2)")
       .IsRequired();

                entity.Property(e => e.ZARAmount)
                      .HasColumnType("decimal(18,2)")
                      .IsRequired();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}

