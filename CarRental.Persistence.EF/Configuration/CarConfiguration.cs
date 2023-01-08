using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRental.Persistence.EF.Configuration
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> ab)
        {
            ab.Property(x => x.AVGFuelConsumption).HasPrecision(3, 1);
            ab.HasOne(x => x.CarAddress)
                .WithMany(x => x.Cars)
                .HasForeignKey(x => x.CarAddressId);
            ab.HasOne(x => x.PriceCategory)
                .WithMany(x => x.Cars)
                .HasForeignKey(x => x.PriceCategoryId);
        }
    }
}
