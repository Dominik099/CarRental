using CarRental.Application.Functions.CarAddresses.Commands.AddCarAddress;
using CarRental.Application.Functions.Cars.Commands.AddCar;
using CarRental.Application.Functions.Cars.Queries.GetCarModelsCommon;
using CarRental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Contracts.Persistence
{
    public interface ICarRepository : IAsyncRepository<Car>
    {
        bool DriverIsNotTooYoung(int carId, DateTime driverLicencedate);
        Task<bool> IsCarAlreadyExistAsync(AddCarCommand car);
        Task<int> NumberOfCars(string mark, string model);

        Task<List<CarsDto>> GetCarsListAsync();
        Task<List<CarsDto>> GetCarsByCarAddressAsync(int id);
        //Task<Car> FindAndUpdateAlreadyExistCar(AddCarCommand car);
    }
}
