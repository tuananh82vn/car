using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CarSales_Mini.DAL.Entities
{
    public partial class CarSalesDbContext : DbContext
    {
        public CarSalesDbContext()
        {
        }

        public CarSalesDbContext(DbContextOptions<CarSalesDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public virtual DbSet<Vehicle> Vehicle { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Vehicle>(entity =>
            {
                //entity.Property(e => e.Color).HasMaxLength(250);

                //entity.Property(e => e.CreatedBy)
                //    .IsRequired()
                //    .HasMaxLength(128)
                //    .HasDefaultValueSql("(user_name())");

                //entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                //entity.Property(e => e.Make).HasMaxLength(250);

                //entity.Property(e => e.Model).HasMaxLength(250);

                //entity.Property(e => e.UniqueId)
                //    .IsRequired()
                //    .HasMaxLength(6)
                //    .HasDefaultValueSql("([dbo].[RandomString]((6)))");

                //entity.Property(e => e.UpdatedBy).HasMaxLength(128);

                //entity.Property(e => e.UpdatedOn)
                //    .HasColumnType("datetime");

                modelBuilder.Entity<Vehicle>()
                    .ToTable("Vehicle")
                    .HasDiscriminator<string>("VehicleType")
                    .HasValue<Car>("Car")
                    .HasValue<Bike>("Bike");
            });


        }
    }
}
