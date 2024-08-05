using Microsoft.EntityFrameworkCore;
using HexagonalDesignPatterns.Domain.Entities;

namespace HexagonalDesignPatterns.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Smartphone> Smartphones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Smartphone>(entity =>
            {
                entity.HasKey(s => s.Id);

                entity.Property(s => s.Model)
                    .IsRequired();

                entity.Property(s => s.Manufacturer)
                    .IsRequired();

                entity.OwnsOne(s => s.Specifications, spec =>
                {
                    spec.Property(p => p.ScreenSize)
                        .HasMaxLength(50);

                    spec.Property(p => p.BatteryLife)
                        .IsRequired();
                });

                entity.Ignore(s => s.PricingStrategy);
               
                entity.Property(s => s.BasePrice)
                   .HasColumnType("decimal(18,2)");
            });

        }
    }
}
