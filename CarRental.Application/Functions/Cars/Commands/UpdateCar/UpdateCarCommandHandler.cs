using AutoMapper;
using CarRental.Application.Authorization;
using CarRental.Application.Authorization.Common;
using CarRental.Application.Contracts.Persistence;
using CarRental.Application.Functions.CarAddresses.Exceptions;
using CarRental.Application.Functions.RentalCalculator.Exceptions;
using CarRental.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Functions.Cars.Commands.UpdateCar
{
    public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand, Unit>
    {
        private readonly ICarRepository _carRepository;
        private readonly ICarAddressRepository _carAddressRepository;
        private readonly IAuthorizationService _authorizationService;
        private readonly IUserContext _userContext;

        public UpdateCarCommandHandler(ICarRepository carRepository, IAuthorizationService authorizationService, 
            ICarAddressRepository carAddressRepository, IUserContext userContext)
        {
            _carRepository = carRepository;
            _authorizationService = authorizationService;
            _carAddressRepository = carAddressRepository;
            _userContext = userContext;
        }

        public async Task<Unit> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
        {
            var car = await _carRepository.GetByIdAsync(request.Id);

            if (car == null)
            {
                throw new CarNotFoundException();
            }

            var carAddress = await _carAddressRepository.GetByIdAsync(car.CarAddressId);

            var authorizationResult = _authorizationService.AuthorizeAsync(_userContext.User, carAddress,
              new ResourceOperationRequirement(ResourceOperation.Update)).Result;

            if (!authorizationResult.Succeeded)
            {
                throw new ForbidException();
            }

            car.Mark = request.Mark;
            car.Model = request.Model;
            car.AVGFuelConsumption = request.AVGFuelConsumption;
            car.RegistrationNumber = request.RegistrationNumber;
            car.PriceCategoryId = request.PriceCategoryId;


            await _carRepository.UpdateAsync(car);

            return Unit.Value;
        }
    }
}
