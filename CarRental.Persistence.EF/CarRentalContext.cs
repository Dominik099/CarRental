﻿using Microsoft.EntityFrameworkCore;
using CarRental.Domain.Entities;
using CarRental.Persistence.EF.Configuration;
using CarRental.Persistence.EF.SeedData;

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
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Rental> Rentals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new CarConfiguration().Configure(modelBuilder.Entity<Car>());
            new CarAddressConfiguration().Configure(modelBuilder.Entity<CarAddress>());
            new PriceCategoryConfiguration().Configure(modelBuilder.Entity<PriceCategory>());
            new RoleConfiguration().Configure(modelBuilder.Entity<Role>());
            new UserConfiguration().Configure(modelBuilder.Entity<User>());
            new RentalConfiguration().Configure(modelBuilder.Entity<Rental>());

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CarRentalContext).Assembly);

            foreach (var item in CarsSeed.Get())
            {
                modelBuilder.Entity<Car>().HasData(item);
            }

            foreach (var item in CarAddressesSeed.Get())
            {
                modelBuilder.Entity<CarAddress>().HasData(item);
            }

            foreach (var item in PriceCategoriesSeed.Get())
            {
                modelBuilder.Entity<PriceCategory>().HasData(item);
            }

            foreach (var item in RolesSeed.Get())
            {
                modelBuilder.Entity<Role>().HasData(item);
            }

        }


    }
}