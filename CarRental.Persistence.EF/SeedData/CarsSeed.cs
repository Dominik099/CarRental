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
                YearOfProduction = 2004,
                Engine = "2.0 HDI 136HP",
                AVGFuelConsumption = 6.2m,
                PriceCategoryId = PriceCategoriesSeedId.Standard,
                NumberOfCars = 5,
                CarAddressId = CarAddressesSeedId.Rzeszow
            };
            cars.Add(car1);

            var car2 = new Car()
            {
                Id = 2,
                Mark = "Peugeot",
                Model = "406 Coupe",
                YearOfProduction = 1998,
                Engine = "2.0 132HP",
                AVGFuelConsumption = 10.5m,
                PriceCategoryId = PriceCategoriesSeedId.Standard,
                NumberOfCars = 2,
                CarAddressId = CarAddressesSeedId.Krakow
            };
            cars.Add(car2);

            var car3 = new Car()
            {
                Id =3,
                Mark = "Suzuki",
                Model = "Swift",
                YearOfProduction = 2017,
                Engine = "1.2 78HP",
                AVGFuelConsumption = 5.5m,
                PriceCategoryId = PriceCategoriesSeedId.Standard,
                NumberOfCars = 4,
                CarAddressId = CarAddressesSeedId.Rzeszow
            };
            cars.Add(car3);

            var car4 = new Car()
            {
                Id = 4,
                Mark = "Audi",
                Model = "S8",
                YearOfProduction = 2022,
                Engine = "4.0 TFSI 571HP",
                AVGFuelConsumption = 13.5m,
                PriceCategoryId = PriceCategoriesSeedId.Premium,
                NumberOfCars = 2,
                CarAddressId = CarAddressesSeedId.Rzeszow,
            };
            cars.Add(car4);

            var car5 = new Car()
            {
                Id = 5,
                Mark = "Mercedes-Benz",
                Model = "GLE",
                YearOfProduction = 2021,
                Engine = "2.0 211HP",
                AVGFuelConsumption = 9.2m,
                PriceCategoryId = PriceCategoriesSeedId.Premium,
                NumberOfCars = 9,
                CarAddressId = CarAddressesSeedId.Krakow,
            };
            cars.Add(car5);

            var car6 = new Car()
            {
                Id = 6,
                Mark = "Volkswagen",
                Model = "T-Roc",
                YearOfProduction = 2022,
                Engine = "1.5 TSI 150HP",
                AVGFuelConsumption = 5.5m,
                PriceCategoryId = PriceCategoriesSeedId.Medium,
                NumberOfCars = 1,
                CarAddressId = CarAddressesSeedId.Krakow,
            };
            cars.Add(car6);

            var car7 = new Car()
            {
                Id = 7,
                Mark = "Citroen",
                Model = "DS4",
                YearOfProduction = 2012,
                Engine = "1.6 HDI 114HP",
                AVGFuelConsumption = 5.5m,
                PriceCategoryId = PriceCategoriesSeedId.Medium,
                NumberOfCars = 3,
                CarAddressId = CarAddressesSeedId.Krakow,
            };
            cars.Add(car7);

            var car8 = new Car()
            {
                Id = 8,
                Mark = "Skoda",
                Model = "Octavia",
                YearOfProduction = 2006,
                Engine = "2.0 TFSI 200HP",
                AVGFuelConsumption = 9.0m,
                PriceCategoryId = PriceCategoriesSeedId.Basic,
                NumberOfCars = 5,
                CarAddressId = CarAddressesSeedId.Wroclaw,
            };
            cars.Add(car8);

            var car9 = new Car()
            {
                Id = 9,
                Mark = "Seat",
                Model = "Leon",
                YearOfProduction = 2007,
                Engine = "1.6 102HP",
                AVGFuelConsumption = 8.5m,
                PriceCategoryId = PriceCategoriesSeedId.Basic,
                NumberOfCars = 2,
                CarAddressId = CarAddressesSeedId.Wroclaw,
            };
            cars.Add(car9);

            return cars;
        }
    }
}
