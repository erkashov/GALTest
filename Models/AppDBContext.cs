using Microsoft.EntityFrameworkCore;
using System;

namespace GALTest.Models
{
    public class AppDBContext : DbContext
    {
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Offer>(entity =>
            {
                entity.HasKey(o => o.Id);
                entity.Property(o => o.Brand).IsRequired().HasMaxLength(100);
                entity.Property(o => o.Model).IsRequired().HasMaxLength(100);
                entity.Property(o => o.RegisteredAt).IsRequired();

                entity.HasOne(o => o.Supplier)
                      .WithMany(s => s.Offers)
                      .HasForeignKey(o => o.SupplierId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasKey(s => s.Id);
                entity.Property(s => s.Name).IsRequired().HasMaxLength(200);
                entity.Property(s => s.CreatedAt).IsRequired();
            });
        }
    }
}
