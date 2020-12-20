using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistence.Models;

namespace Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Sensor> Sensors { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Vehicle>();

            var sensor = builder.Entity<Sensor>();
            sensor.HasKey(x => x.ID);
            sensor.Property(x => x.ID).HasColumnName("id").IsRequired().ValueGeneratedOnAdd();
            sensor.Property(x => x.Name).HasColumnName("name").IsRequired();
            sensor.Property(x => x.Value).HasColumnName("value").IsRequired();
            sensor.ToTable("Sensors");

            var status = builder.Entity<Status>();
            status.HasKey(x => x.ID);
            status.Property(x => x.ID).HasColumnName("id").IsRequired().ValueGeneratedOnAdd();
            status.Property(x => x.VehicleID).HasColumnName("vehicleid").IsRequired();
            status.Property(x => x.Latitude).HasColumnName("latitude").IsRequired();
            status.Property(x => x.Longitude).HasColumnName("longitude").IsRequired();
            status.HasMany(x => x.Sensors).WithOne().HasForeignKey(y => y.StatusID);
            status.ToTable("Status");

            var vehicle = builder.Entity<Vehicle>();
            vehicle.HasKey(x => x.ID);
            vehicle.Property(x => x.ID).HasColumnName("id").IsRequired().ValueGeneratedOnAdd();
            vehicle.Property(x => x.Name).HasColumnName("name").IsRequired();
            vehicle.Property(x => x.Code).HasColumnName("code").IsRequired();
            vehicle.HasIndex(x => x.Name).IsUnique();
            vehicle.HasIndex(x => x.Code).IsUnique();
            vehicle.ToTable("Vehicles");
        }
    }
}
