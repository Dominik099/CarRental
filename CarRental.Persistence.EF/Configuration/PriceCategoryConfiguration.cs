using CarRental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarRental.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRental.Persistence.EF.Configuration
{
    public class PriceCategoryConfiguration : IEntityTypeConfiguration<PriceCategory>
    {
        public void Configure(EntityTypeBuilder<PriceCategory> ab)
        {
            ab.Property(x => x.Multiplier).HasPrecision(2, 1);
        }
    }
}
