using CarRental.Application.Contracts.Persistence;
using CarRental.Application.Functions.CarAddresses.Exceptions;
using CarRental.Application.Functions.CarAddresses.Queries.GetCarAddressList;
using CarRental.Application.Functions.CarAddresses.Queries.GetCarAddressModelsCommon;
using CarRental.Domain.Entities;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<CarAddressDto>> GetCarAddressesAsync(string mark, string model)
        {
            var carAddressList = new List<CarAddressDto>();

            var addressId = await _dbContext.Cars.Where(x => x.Mark.Equals(mark) && x.Model.Equals(model)).GroupBy(x => new { x.CarAddressId })
                .Select(x => new CarAddressIdDto { Id = x.Key.CarAddressId }).ToListAsync();

            if (addressId == null)
            {
                throw new CarAddressNotFoundException();
            }

            foreach (var id in addressId)
            {
                var address = await _dbContext.CarAddresses.Where(x => x.Id == id.Id).FirstOrDefaultAsync();

                var newAddress = new CarAddressDto()
                {
                    Id = address.Id,
                    City = address.City,
                    Street = address.Street,
                    PostalCode = address.PostalCode,
                };
                carAddressList.Add(newAddress);
            }

            return carAddressList;
        }

        public bool IsCarAddressExist (int carAddressId)
        {
            var isAddressExist = _dbContext.CarAddresses.Any(x => x.Id == carAddressId);

            return isAddressExist;
        }
    }
}
