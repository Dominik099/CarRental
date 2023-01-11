using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Domain.Entities;

namespace CarRental.Persistence.EF.SeedData
{
    public class CarsSeed
    {
        public static List<Car> Get()
        {
            var categoryPriceId = PriceCategoriesSeed.Get();
            var carAddressId = CarAddressesSeed.Get();

            List<Car> cars = new List<Car>();

            var car1 = new Car()
            {
                Id = 1,
                Mark = "Peugeot",
                Model = "407",
                AVGFuelConsumption = 6.2m,
                RegistrationNumber = "RZ52475",
                PriceCategoryId = PriceCategoriesSeedId.Standard,
                CarAddressId = CarAddressesSeedId.Rzeszow
            };
            cars.Add(car1);

            var car2 = new Car()
            {
                Id = 2,
                Mark = "Peugeot",
                Model = "406 Coupe",
                AVGFuelConsumption = 10.5m,
                RegistrationNumber = "KR63975",
                PriceCategoryId = PriceCategoriesSeedId.Standard,
                CarAddressId = CarAddressesSeedId.Krakow
            };
            cars.Add(car2);

            var car3 = new Car()
            {
                Id = 3,
                Mark = "Suzuki",
                Model = "Swift",
                AVGFuelConsumption = 5.5m,
                RegistrationNumber = "RZ12846",
                PriceCategoryId = PriceCategoriesSeedId.Standard,
                CarAddressId = CarAddressesSeedId.Rzeszow
            };
            cars.Add(car3);

            var car4 = new Car()
            {
                Id = 4,
                Mark = "Audi",
                Model = "S8",
                AVGFuelConsumption = 13.5m,
                RegistrationNumber = "RZ91476",
                PriceCategoryId = PriceCategoriesSeedId.Premium,
                CarAddressId = CarAddressesSeedId.Rzeszow,
            };
            cars.Add(car4);

            var car5 = new Car()
            {
                Id = 5,
                Mark = "Mercedes-Benz",
                Model = "GLE",
                AVGFuelConsumption = 9.2m,
                RegistrationNumber = "KR71584",
                PriceCategoryId = PriceCategoriesSeedId.Premium,
                CarAddressId = CarAddressesSeedId.Krakow,
            };
            cars.Add(car5);

            var car6 = new Car()
            {
                Id = 6,
                Mark = "Volkswagen",
                Model = "T-Roc",
                AVGFuelConsumption = 5.5m,
                RegistrationNumber = "KR14582",
                PriceCategoryId = PriceCategoriesSeedId.Medium,
                CarAddressId = CarAddressesSeedId.Krakow,
            };
            cars.Add(car6);

            var car7 = new Car()
            {
                Id = 7,
                Mark = "Citroen",
                Model = "DS4",
                AVGFuelConsumption = 5.5m,
                RegistrationNumber = "KR61483",
                PriceCategoryId = PriceCategoriesSeedId.Medium,
                CarAddressId = CarAddressesSeedId.Krakow,
            };
            cars.Add(car7);

            var car8 = new Car()
            {
                Id = 8,
                Mark = "Skoda",
                Model = "Octavia",
                AVGFuelConsumption = 9.0m,
                RegistrationNumber = "DW31674",
                PriceCategoryId = PriceCategoriesSeedId.Basic,
                CarAddressId = CarAddressesSeedId.Wroclaw,
            };
            cars.Add(car8);

            var car9 = new Car()
            {
                Id = 9,
                Mark = "Seat",
                Model = "Leon",
                AVGFuelConsumption = 8.5m,
                RegistrationNumber = "DW71463",
                PriceCategoryId = PriceCategoriesSeedId.Basic,
                CarAddressId = CarAddressesSeedId.Wroclaw,
            };
            cars.Add(car9);

            return cars;
        }
    }
}
