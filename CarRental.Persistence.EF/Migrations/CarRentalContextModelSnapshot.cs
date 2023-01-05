﻿// <auto-generated />
using System;
using CarRental.Persistence.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarRental.Persistence.EF.Migrations
{
    [DbContext(typeof(CarRentalContext))]
    partial class CarRentalContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CarRental.Domain.Entities.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("AVGFuelConsumption")
                        .HasPrecision(3, 1)
                        .HasColumnType("decimal(3,1)");

                    b.Property<int>("CarAddressId")
                        .HasColumnType("int");

                    b.Property<string>("Engine")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Mark")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfCars")
                        .HasColumnType("int");

                    b.Property<int>("PriceCategoryId")
                        .HasColumnType("int");

                    b.Property<int>("YearOfProduction")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarAddressId");

                    b.HasIndex("PriceCategoryId");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AVGFuelConsumption = 6.2m,
                            CarAddressId = 1,
                            Engine = "2.0 HDI 136HP",
                            Mark = "Peugeot",
                            Model = "407",
                            NumberOfCars = 5,
                            PriceCategoryId = 2,
                            YearOfProduction = 2004
                        },
                        new
                        {
                            Id = 2,
                            AVGFuelConsumption = 10.5m,
                            CarAddressId = 2,
                            Engine = "2.0 132HP",
                            Mark = "Peugeot",
                            Model = "406 Coupe",
                            NumberOfCars = 2,
                            PriceCategoryId = 2,
                            YearOfProduction = 1998
                        },
                        new
                        {
                            Id = 3,
                            AVGFuelConsumption = 5.5m,
                            CarAddressId = 1,
                            Engine = "1.2 78HP",
                            Mark = "Suzuki",
                            Model = "Swift",
                            NumberOfCars = 4,
                            PriceCategoryId = 2,
                            YearOfProduction = 2017
                        },
                        new
                        {
                            Id = 4,
                            AVGFuelConsumption = 13.5m,
                            CarAddressId = 1,
                            Engine = "4.0 TFSI 571HP",
                            Mark = "Audi",
                            Model = "S8",
                            NumberOfCars = 2,
                            PriceCategoryId = 4,
                            YearOfProduction = 2022
                        },
                        new
                        {
                            Id = 5,
                            AVGFuelConsumption = 9.2m,
                            CarAddressId = 2,
                            Engine = "2.0 211HP",
                            Mark = "Mercedes-Benz",
                            Model = "GLE",
                            NumberOfCars = 9,
                            PriceCategoryId = 4,
                            YearOfProduction = 2021
                        },
                        new
                        {
                            Id = 6,
                            AVGFuelConsumption = 5.5m,
                            CarAddressId = 2,
                            Engine = "1.5 TSI 150HP",
                            Mark = "Volkswagen",
                            Model = "T-Roc",
                            NumberOfCars = 1,
                            PriceCategoryId = 3,
                            YearOfProduction = 2022
                        },
                        new
                        {
                            Id = 7,
                            AVGFuelConsumption = 5.5m,
                            CarAddressId = 2,
                            Engine = "1.6 HDI 114HP",
                            Mark = "Citroen",
                            Model = "DS4",
                            NumberOfCars = 3,
                            PriceCategoryId = 3,
                            YearOfProduction = 2012
                        },
                        new
                        {
                            Id = 8,
                            AVGFuelConsumption = 9.0m,
                            CarAddressId = 3,
                            Engine = "2.0 TFSI 200HP",
                            Mark = "Skoda",
                            Model = "Octavia",
                            NumberOfCars = 5,
                            PriceCategoryId = 1,
                            YearOfProduction = 2006
                        },
                        new
                        {
                            Id = 9,
                            AVGFuelConsumption = 8.5m,
                            CarAddressId = 3,
                            Engine = "1.6 102HP",
                            Mark = "Seat",
                            Model = "Leon",
                            NumberOfCars = 2,
                            PriceCategoryId = 1,
                            YearOfProduction = 2007
                        });
                });

            modelBuilder.Entity("CarRental.Domain.Entities.CarAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("City")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PostalCode")
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<string>("Street")
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.HasKey("Id");

                    b.ToTable("CarAddresses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Rzeszow",
                            PostalCode = "35-064",
                            Street = "Targowa 17"
                        },
                        new
                        {
                            Id = 2,
                            City = "Krakow",
                            PostalCode = "30-072",
                            Street = "Rostafinskiego 9"
                        },
                        new
                        {
                            Id = 3,
                            City = "Wroclaw",
                            PostalCode = "50-416",
                            Street = "Generala Romualda Traugutta 25"
                        });
                });

            modelBuilder.Entity("CarRental.Domain.Entities.PriceCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Multiplier")
                        .HasPrecision(2, 1)
                        .HasColumnType("decimal(2,1)");

                    b.HasKey("Id");

                    b.ToTable("PriceCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Category = "Basic",
                            Multiplier = 1.0m
                        },
                        new
                        {
                            Id = 2,
                            Category = "Standard",
                            Multiplier = 1.3m
                        },
                        new
                        {
                            Id = 3,
                            Category = "Medium",
                            Multiplier = 1.6m
                        },
                        new
                        {
                            Id = 4,
                            Category = "Premium",
                            Multiplier = 2.0m
                        });
                });

            modelBuilder.Entity("CarRental.Domain.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "User"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Manager"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Admin"
                        });
                });

            modelBuilder.Entity("CarRental.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CarRental.Domain.Entities.Car", b =>
                {
                    b.HasOne("CarRental.Domain.Entities.CarAddress", "CarAddress")
                        .WithMany("Cars")
                        .HasForeignKey("CarAddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarRental.Domain.Entities.PriceCategory", "PriceCategory")
                        .WithMany("Cars")
                        .HasForeignKey("PriceCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarAddress");

                    b.Navigation("PriceCategory");
                });

            modelBuilder.Entity("CarRental.Domain.Entities.User", b =>
                {
                    b.HasOne("CarRental.Domain.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("CarRental.Domain.Entities.CarAddress", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("CarRental.Domain.Entities.PriceCategory", b =>
                {
                    b.Navigation("Cars");
                });
#pragma warning restore 612, 618
        }
    }
}
