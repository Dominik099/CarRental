using Microsoft.EntityFrameworkCore;
using CarRental.Domain.Entities;
using CarRental.Persistence.EF.Configuration;

namespace CarRental.Persistence.EF
{
    public class CarRentalContext : DbContext
    {
        public CarRentalContext(DbContextOptions<CarRentalContext> options) : base(options)
        {
            
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<CarAddress> CarAddresses { get; set; }
        public DbSet<PriceCategory> PriceCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new CarConfiguration().Configure(modelBuilder.Entity<Car>());
            new CarAddressConfiguration().Configure(modelBuilder.Entity<CarAddress>());
            new PriceCategoryConfiguration().Configure(modelBuilder.Entity<PriceCategory>());

        }


    }
}