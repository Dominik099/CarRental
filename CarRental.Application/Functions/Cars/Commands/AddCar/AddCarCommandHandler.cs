using CarRental.Application.Authorization.Common;
using CarRental.Application.Contracts.Persistence;
using CarRental.Application.Functions.CarAddresses.Exceptions;
using CarRental.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Functions.Cars.Commands.AddCar
{
    public class AddCarCommandHandler : IRequestHandler<AddCarCommand, Unit>
    {
        private readonly ICarAddressRepository _carAddressRepository;
        private readonly ICarRepository _carRepository;
        private readonly IAuthorizationService _authorizationService;

        public AddCarCommandHandler(ICarAddressRepository carAddressRepository, IAuthorizationService authorizationService, 
            ICarRepository carRepository)
        {
            _carAddressRepository = carAddressRepository;
            _authorizationService = authorizationService;
            _carRepository = carRepository;
        }

        public async Task<Unit> Handle(AddCarCommand request, CancellationToken cancellationToken)
        {
            //var carAlreadyExist = await _carRepository.IsCarAlreadyExistAsync(request);

            //if (carAlreadyExist)
            //{
            //    var update = await _carRepository.FindAndUpdateAlreadyExistCar(request);
            //    _carRepository.UpdateAsync(update);

            //    return Unit.Value;

            //}
            var carAddress = await _carAddressRepository.GetByIdAsync(request.CarAddressId);

            var authorizationResult = _authorizationService.AuthorizeAsync(request.User, carAddress,
    new ResourceOperationRequirement(ResourceOperation.AddCar)).Result;

            if (!authorizationResult.Succeeded)
            {
                throw new ForbidException();
            }

            var newCar = new Car()
            {
                Mark = request.Mark,
                Model = request.Model,
                AVGFuelConsumption = request.AVGFuelConsumption,
                RegistrationNumber= request.RegistrationNumber,
                CarAddressId = request.CarAddressId,
                PriceCategoryId = request.PriceCategoryId,
            };

            newCar = await _carRepository.AddAsync(newCar);

            return Unit.Value;

        }
    }
}
