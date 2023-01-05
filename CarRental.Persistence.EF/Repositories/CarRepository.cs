using CarRental.Application.Contracts.Persistence;
using CarRental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Application.Functions.RentalCalculator.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Persistence.EF.Repositories
{
    public class CarRepository : BaseRepository<Car>, ICarRepository 
    {
        public CarRepository(CarRentalContext dbContext) : base(dbContext)
        { 

        }

        public async Task<bool> DriverIsNotTooYoung(int carId, DateTime driverLicenceDate)
        {
            var selectedCar = await _dbContext.Cars.FirstOrDefaultAsync(x => x.Id== carId);

            if (selectedCar is null)
                throw new CarNotFoundException();

            var daysOfThreeYears = 1095;
            var checkedLicense = true;

            var driverLicenseTime = (DateTime.UtcNow - driverLicenceDate).TotalDays < (daysOfThreeYears + 1);
            
            if (selectedCar.PriceCategoryId == 4 && driverLicenseTime)
            {
                checkedLicense = false;
            }

            return await Task.FromResult(checkedLicense);
        }
    }
}
