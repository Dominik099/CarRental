using CarRental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Persistence.EF.SeedData
{
    public class CarAddressesSeed
    {

        public static List<CarAddress> Get()
        {
            List<CarAddress> carAddresses = new List<CarAddress>();

            var address1 = new CarAddress()
            {
                Id = CarAddressesSeedId.Rzeszow,
                City = "Rzeszow",
                Street = "Targowa 17",
                PostalCode = "35-064"
            };
            carAddresses.Add(address1);

            var address2 = new CarAddress()
            {
                Id = CarAddressesSeedId.Krakow,
                City = "Krakow",
                Street = "Rostafinskiego 9",
                PostalCode = "30-072"
            };
            carAddresses.Add(address2);

            var address3 = new CarAddress()
            {
                Id = CarAddressesSeedId.Wroclaw,
                City = "Wroclaw",
                Street = "Generala Romualda Traugutta 25",
                PostalCode = "50-416"
            };
            carAddresses.Add(address3);

            return carAddresses;
        }
    }
}
