using CarRental.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Persistence.EF.Configuration
{
    public class RentalConfiguration : IEntityTypeConfiguration<Rental>
    {
        public void Configure(EntityTypeBuilder<Rental> builder)
        {
            builder.Property(x => x.ReturnDate)
                .HasColumnType("date");

            builder.Property(x => x.RentDate)
                .HasColumnType("date");
        }
    }
}
