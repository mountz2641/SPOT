using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistence.Models;

namespace Infrastructure.Persistence
{
    public class DataContext : DbContext
    {
        public DbSet<VehicleModel> Vehicles { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<VehicleModel>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name);
            });
        }
    }
}
