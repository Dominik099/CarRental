using CarRental.Application.Functions.Cars.Queries.GetCarsList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Contracts.Persistence
{
    public interface IRentalCalculator
    {
        public decimal CalculateForPeriod(DateTime rentalDate, DateTime returnDate);
        public decimal CalculateForCategory(CarViewModel selectedCar, decimal totalCost);
        public decimal CalculateForDriverLicenceDate(DateTime driverLicenceDate, decimal totalCost);
        public decimal CalculateForFewPieces(CarViewModel selectedCar, decimal totalCost);
        public decimal CalculateForFuelCost(CarViewModel selectedCar, int kilometers);
        public decimal CalculateNettoToBrutto(decimal totalCost);
    }
}
