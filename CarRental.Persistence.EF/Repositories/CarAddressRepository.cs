using CarRental.Application.Contracts.Persistence;
using CarRental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Persistence.EF.Repositories
{
    public class CarAddressRepository : BaseRepository<CarAddress>, ICarAddressRepository
    {
        public CarAddressRepository(CarRentalContext dbContext) : base(dbContext)
        {

        }

        public bool CityAndStreetAlreadyExist(string city, string street)
        {
            var cityMatches = _dbContext.CarAddresses
                .Any(x => x.City.Equals(city));

            var streetMatches = _dbContext.CarAddresses
                .Any(x => x.Street.Equals(street));

            if (cityMatches && streetMatches)
            {
                return true;
            }

            return false;
        }
    }
}
