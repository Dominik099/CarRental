using CarRental.Application.Contracts.Persistence;
using CarRental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Application.Functions.RentalCalculator.Exceptions;
using Microsoft.EntityFrameworkCore;
using CarRental.Common.Abstractions.Exceptions;
using System.IO;
using CarRental.Application.Functions.CarAddresses.Commands.AddCarAddress;
using CarRental.Application.Functions.Cars.Commands.AddCar;

namespace CarRental.Persistence.EF.Repositories
{
    public class CarRepository : BaseRepository<Car>, ICarRepository 
    {
        public CarRepository(CarRentalContext dbContext) : base(dbContext)
        { 

        }



        public bool DriverIsNotTooYoung(int carId, DateTime driverLicenceDate)
        {
            var selectedCar =  _dbContext.Cars.FirstOrDefault(x => x.Id== carId);

            if (selectedCar is null)
                return true;

            var daysOfThreeYears = 1095;
            var checkedLicense = true;

            var driverLicenseTime = (DateTime.UtcNow - driverLicenceDate).TotalDays < (daysOfThreeYears + 1);
            
            if (selectedCar.PriceCategoryId == 4 && driverLicenseTime)
            {
                checkedLicense = false;
            }

            return checkedLicense;
        }

        public Task<bool> IsCarAlreadyExistAsync(AddCarCommand car)
        {
            var matches = _dbContext.Cars
                .Any(x => x.Mark.Equals(car.Mark) && x.Model.Equals(car.Model)
                && x.EngineCapacity.Equals(car.EngineCapacity) && x.EnginePower.Equals(car.EnginePower)
                && x.CarAddressId.Equals(car.CarAddressId));

            //var modelMatches = _dbContext.Cars
            //    .Any(x => x.Model.Equals(car.Model));

            //var engineCapacityMatches = _dbContext.Cars
            //    .Any(x => x.EngineCapacity.Equals(car.EngineCapacity));

            //var enginePowerMatches = _dbContext.Cars
            //    .Any(x => x.EnginePower.Equals(car.EnginePower));

            //if (markMatches && modelMatches && engineCapacityMatches && enginePowerMatches)
            //{
            //    return Task.FromResult(true);
            //}

            //return Task.FromResult(false);

            return Task.FromResult(matches);
        }

        public async Task FindAndUpdateAlreadyExistCar(AddCarCommand car)
        {
            var markAlreadyExist =  await _dbContext.Cars
                .Where(x => x.Mark == car.Mark && x.Model == car.Model
                && x.EngineCapacity == car.EngineCapacity && x.EnginePower == car.EnginePower
                && x.CarAddressId == car.CarAddressId)
                .FirstOrDefaultAsync();

            markAlreadyExist.NumberOfCars += 1;

            _dbContext.Cars.Update(markAlreadyExist);
            _dbContext.SaveChanges();

        }
    }
}
