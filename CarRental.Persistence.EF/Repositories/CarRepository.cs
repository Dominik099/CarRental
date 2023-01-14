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
using CarRental.Application.Functions.Cars.Queries.GetCarModelsCommon;

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

        public async Task<List<CarsDto>> GetCarsByCarAddressAsync(int id)
        {
            var cars = await _dbContext.Cars.Where(x => x.CarAddressId == id)
                .GroupBy(x => new { x.Mark, x.Model })
                .Select(x => new CarsDto { Mark = x.Key.Mark, Model = x.Key.Model }).ToListAsync();

            return cars;
        }

        public async Task<List<CarsDto>> GetCarsListAsync()
        {
            var carsList = await _dbContext.Cars.GroupBy(x => new { x.Mark, x.Model }).Select(x => new CarsDto { Mark = x.Key.Mark, Model = x.Key.Model }).ToListAsync();

            return carsList;
        }

        public Task<bool> IsCarAlreadyExistAsync(AddCarCommand car)
        {
            var matches = _dbContext.Cars
                .Any(x => x.Mark.Equals(car.Mark) && x.Model.Equals(car.Model)
                && x.CarAddressId.Equals(car.CarAddressId));

            return Task.FromResult(matches);
        }

        public async Task<int> NumberOfCars(string mark, string model)
        {
            var cars = await _dbContext.Cars
                .Where(x => x.Mark.Equals(mark) && x.Model.Equals(model))
                .ToListAsync();

            var numberOfCars = cars.Count();

            return numberOfCars;
        }
    }
}
