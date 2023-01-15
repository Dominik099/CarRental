using CarRental.Application.Authorization;
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
        private readonly IUserContext _userContext;

        public AddCarCommandHandler(ICarAddressRepository carAddressRepository, IAuthorizationService authorizationService, 
            ICarRepository carRepository, IUserContext userContext)
        {
            _carAddressRepository = carAddressRepository;
            _authorizationService = authorizationService;
            _carRepository = carRepository;
            _userContext = userContext;
        }

        public async Task<Unit> Handle(AddCarCommand request, CancellationToken cancellationToken)
        {
 
            var carAddress = await _carAddressRepository.GetByIdAsync(request.CarAddressId);

            var authorizationResult = _authorizationService.AuthorizeAsync(_userContext.User, carAddress,
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
