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
        private decimal fuelPrice = 7.48m;
        private decimal baseCost = 250.0m;

        public decimal CalculateForPeriod(DateTime rentalDate, DateTime returnDate)
        {
            var periodCost = baseCost * (returnDate - rentalDate).Days;
            return periodCost;
        }

        public decimal CalculateForCategory(CarViewModel selectedCar, decimal totalCost)
        {
            var categoryCost = totalCost * selectedCar.PriceCategory.Multiplier;
            return categoryCost;
        }

        public decimal CalculateForDriverLicenceDate(DateTime driverLicenceDate, decimal totalCost)
        {
            var youngDriverCost = totalCost + (totalCost * 0.2m);
            return youngDriverCost;
        }

        public decimal CalculateForFewPieces(CarViewModel selectedCar, decimal totalCost)
        {
            var fewPiecesCost = totalCost + totalCost * 0.15m;
            return fewPiecesCost;
        }

        public decimal CalculateForFuelCost(CarViewModel selectedCar, int kilometers)
        {
            var fuelCost = kilometers / 100 * selectedCar.AVGFuelConsumption * fuelPrice;
            return fuelCost;
        }

        public decimal CalculateNettoToBrutto(decimal totalCost)
        {
            var totalCostBrutto = totalCost + totalCost * 0.23m;
            return totalCostBrutto;
        }
    }
}
