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
using CarRental.Application.Functions.RentalCalculator.Exceptions;
using FluentValidation.Results;

namespace CarRental.Application.Functions.RentalCalculator
{
    public class RentalCalculatedQueryHandler : IRequestHandler<RentalCalculatedQuery, RentalCalculatedQueryResponse>
    {
        private decimal fuelPrice = 7.48m;
        private decimal baseCost = 250.0m;
        private decimal youngDriverCost = 0;
        private decimal fewPiecesCost = 0;
        private int daysOfFiveYears = 1825;

        private readonly ICarRepository _carRepository;
        private readonly IAsyncRepository<PriceCategory> _priceCategoryRepository;

        public RentalCalculatedQueryHandler(ICarRepository carRepository, IAsyncRepository<PriceCategory> priceCategoryRepository)
        {
            _carRepository = carRepository;
            _priceCategoryRepository = priceCategoryRepository;
        }

        public async Task<RentalCalculatedQueryResponse> Handle(RentalCalculatedQuery request, CancellationToken cancellationToken)
        {
            var selectedCar = await _carRepository.GetByIdAsync(request.CarId);

            if (selectedCar is null)
                throw new CarNotFoundException();

            var priceCategory = await _priceCategoryRepository.GetByIdAsync(selectedCar.PriceCategoryId);

            var periodCost = baseCost * (request.ReturnDate - request.RentalDate).Days;
            var categoryCost = periodCost * priceCategory.Multiplier - periodCost;
            if ((DateTime.UtcNow - request.DriverLicenceDate).TotalDays < (daysOfFiveYears + 1))
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

            var totalCost = new RentalCalculatedQueryResponse()
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
