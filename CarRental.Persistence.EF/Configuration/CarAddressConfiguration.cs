using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Persistence.EF.Configuration
{
    public class CarAddressConfiguration : IEntityTypeConfiguration<CarAddress>
    {
        public void Configure(EntityTypeBuilder<CarAddress> ab)
        {
            ab.Property(x => x.City).HasMaxLength(50);
            ab.Property(x => x.Street).HasMaxLength(70);
            ab.Property(x => x.PostalCode).HasMaxLength(6);
        }
    }
}
