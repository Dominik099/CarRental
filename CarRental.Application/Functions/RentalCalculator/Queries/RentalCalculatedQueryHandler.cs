using CarRental.Application.Contracts.Persistence;
using CarRental.Application.Functions.Cars.Queries.GetCarsList;
using CarRental.Application.Functions.RentalCalculator.Queries;
using CarRental.Application.RentalCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using CarRental.Application.Functions.Cars.Queries.GetCarById;
using CarRental.Domain.Entities;
using AutoMapper;

namespace CarRental.Application.Functions.RentalCalculator
{
    public class RentalCalculatedQueryHandler : IRequestHandler<RentalCalculatedQuery, CalculatedViewModel>
    {
        private decimal fuelPrice = 7.48m;
        private decimal baseCost = 250.0m;
        private decimal youngDriverCost = 0;
        private decimal fewPiecesCost = 0;

        private readonly IAsyncRepository<Car> _carRepository;
        private readonly IAsyncRepository<PriceCategory> _priceCategoryRepository;

        public RentalCalculatedQueryHandler(IAsyncRepository<Car> carRepository, IAsyncRepository<PriceCategory> priceCategoryRepository)
        {
            _carRepository = carRepository;
            _priceCategoryRepository = priceCategoryRepository;
        }

        //public decimal CalculateForPeriod(DateTime rentalDate, DateTime returnDate)
        //{
        //    var periodCost = baseCost * (returnDate - rentalDate).Days;
        //    return periodCost;
        //}

        //public decimal CalculateForCategory(CarViewModel selectedCar, decimal totalCost)
        //{
        //    var categoryCost = totalCost * selectedCar.PriceCategory.Multiplier;
        //    return categoryCost;
        //}

        //public decimal CalculateForDriverLicenceDate(DateTime driverLicenceDate, decimal totalCost)
        //{
        //    var youngDriverCost = totalCost + (totalCost * 0.2m);
        //    return youngDriverCost;
        //}

        //public decimal CalculateForFewPieces(CarViewModel selectedCar, decimal totalCost)
        //{
        //    var fewPiecesCost = totalCost + totalCost * 0.15m;
        //    return fewPiecesCost;
        //}

        //public decimal CalculateForFuelCost(CarViewModel selectedCar, int kilometers)
        //{
        //    var fuelCost = kilometers / 100 * selectedCar.AVGFuelConsumption * fuelPrice;
        //    return fuelCost;
        //}

        //public decimal CalculateNettoToBrutto(decimal totalCost)
        //{
        //    var totalCostBrutto = totalCost + totalCost * 0.23m;
        //    return totalCostBrutto;
        //}

        public async Task<CalculatedViewModel> Handle(RentalCalculatedQuery request, CancellationToken cancellationToken)
        {
            var selectedCar = await _carRepository.GetByIdAsync(request.CarId);
            var priceCategory = await _priceCategoryRepository.GetByIdAsync(selectedCar.PriceCategoryId);

            var periodCost = baseCost * (request.ReturnDate - request.RentalDate).Days;
            var categoryCost = periodCost * priceCategory.Multiplier - periodCost;
            if (DateTime.UtcNow.Year - request.DriverLicenceDate.Year < 5)
            {
                youngDriverCost = (periodCost + categoryCost) * 0.2m;
            }

            if (selectedCar.NumberOfCars < 3)
            {
                fewPiecesCost = (periodCost + categoryCost + youngDriverCost) * 0.15m;
            }

            var fuelcost = request.EstimatedKilometers / 100 * selectedCar.AVGFuelConsumption * fuelPrice;

            var totalCostNetto = periodCost + categoryCost + youngDriverCost + fewPiecesCost + fuelcost;
            var totalCostBrutto = totalCostNetto + totalCostNetto * 0.23m;

            var totalCost = new CalculatedViewModel()
            {
                FuelPrice = fuelPrice,
                BaseCost = baseCost,
                PeriodCost = periodCost,
                CategoryCost = categoryCost,
                YoungDriverCost = youngDriverCost,
                FewPiecesCost = fewPiecesCost,
                FuelCost = fuelcost,
                TotalCostNetto = totalCostNetto,
                TotalCostBrutto = totalCostBrutto,
            };

            return totalCost;
        }
    }
}
