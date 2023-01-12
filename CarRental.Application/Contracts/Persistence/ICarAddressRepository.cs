using CarRental.Application.Functions.CarAddresses.Queries.GetCarAddressList;
using CarRental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Contracts.Persistence
{
    public interface ICarAddressRepository : IAsyncRepository<CarAddress>
    {
        bool CityAndStreetAlreadyExist(string city, string street);
        bool IsCarAddressExist(int carAddressId);
        Task<List<CarAddressDto>> GetCarAddressesAsync(string mark, string model);
    }
}
