﻿using CarRental.Application.Contracts.Persistence;
using CarRental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Persistence.EF.Repositories
{
    public class CarRepository : BaseRepository<Car>, ICarRepository 
    {
        public CarRepository(CarRentalContext dbContext) : base(dbContext)
        { 

        }

        public Task<bool> DriverIsNotTooYoung(int carId, DateTime driverLicenceDate)
        {
            var selectedCar = _dbContext.Cars.FirstOrDefault(x => x.Id== carId);

            var driverLicenseTime = (DateTime.Now.Year - driverLicenceDate.Year) < 3;

            var checkedLicense = true;
            
            if (selectedCar.PriceCategoryId == 4 && driverLicenseTime)
            {
                checkedLicense = false;
            }

            return Task.FromResult(checkedLicense);
        }
    }
}