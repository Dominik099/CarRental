using CarRental.Application.Contracts.Persistence;
using CarRental.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Functions.Cars.Commands.AddCar
{
    public class AddCarCommandHandler : IRequestHandler<AddCarCommand, Unit>
    {
        private readonly ICarRepository _carRepository;

        public AddCarCommandHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository; 
        }

        public async Task<Unit> Handle(AddCarCommand request, CancellationToken cancellationToken)
        {
            var carAlreadyExist = await _carRepository.IsCarAlreadyExistAsync(request);

            if (carAlreadyExist)
            {
                var update = _carRepository.FindAndUpdateAlreadyExistCar(request);

                return Unit.Value;

            }

            var newCar = new Car()
            {
                Mark = request.Mark,
                Model = request.Model,
                YearOfProduction = request.YearOfProduction,
                EngineCapacity = request.EngineCapacity,
                EnginePower = request.EnginePower,
                AVGFuelConsumption = request.AVGFuelConsumption,
                NumberOfCars = 1,
                CarAddressId = request.CarAddressId,
                PriceCategoryId = request.PriceCategoryId,
            };

            newCar = await _carRepository.AddAsync(newCar);

            return Unit.Value;

        }
    }
}
