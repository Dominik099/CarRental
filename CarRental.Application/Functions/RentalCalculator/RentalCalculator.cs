using CarRental.Application.Contracts.Persistence;
using CarRental.Application.Functions.Cars.Queries.GetCarsList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Functions.RentalCalculator
{
    public class RentalCalculator : IRentalCalculator
    {
        private decimal fuelCost = 7.48m;
        private decimal baseCost = 250.0m;

        public decimal CalculateForPeriod(DateTime rentalDate, DateTime returnDate)
        {
            var totalPrice = baseCost * (returnDate - rentalDate).Days;
            return totalPrice;
        }
        //public decimal CalculateForMultiplier(CarViewModel selectedCar)
        //{
        //}
    }
}
