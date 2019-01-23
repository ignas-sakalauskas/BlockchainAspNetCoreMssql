using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class CarSalesContext : DbContext
    {
        public CarSalesContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarEntry>()
                .HasMany(c => c.CarSalesEntries)
                .WithOne()
                .IsRequired(); 
        }

        public DbSet<CarEntry> CarEntries { get; set; }

        public DbSet<CarSalesEntry> CarSalesEntries { get; set; }
    }
}
