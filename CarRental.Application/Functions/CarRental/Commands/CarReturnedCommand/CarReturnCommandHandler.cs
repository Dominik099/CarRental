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
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Functions.CarRental.Commands.CarReturnedCommand
{
    public class CarReturnCommandHandler : IRequestHandler<CarReturnCommand, Unit>
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly IUserContext _userContext;
        private readonly IAuthorizationService _authorizationService;
        private readonly ICarRepository _carRepository;
        private readonly ICarAddressRepository _carAddressRepository;

        public CarReturnCommandHandler(IRentalRepository rentalRepository, IUserContext userContext, IAuthorizationService authorizationService,
            ICarRepository carRepository, ICarAddressRepository carAddressRepository)
        {
            _rentalRepository = rentalRepository;
            _userContext = userContext;
            _authorizationService = authorizationService;
            _carRepository = carRepository;
            _carAddressRepository = carAddressRepository;
        }

        public async Task<Unit> Handle(CarReturnCommand request, CancellationToken cancellationToken)
        {
            var rentedCar = await _carRepository.GetByIdAsync(request.CarId);
            var returnedCar = await _rentalRepository.GetByCarIdAsync(request.CarId);

            if (rentedCar == null || returnedCar == null)
            {
                throw new CarNotFoundException();
            }

            var carAddress = await _carAddressRepository.GetByIdAsync(rentedCar.CarAddressId);

            var authorizationResult = _authorizationService.AuthorizeAsync(_userContext.User, carAddress,
                new ResourceOperationRequirement(ResourceOperation.RenturnCar)).Result;

            if (!authorizationResult.Succeeded)
            {
                throw new ForbidException();
            }

            await _rentalRepository.DeleteAsync(returnedCar);

            rentedCar.IsAvailable = true;

            await _carRepository.UpdateAsync(rentedCar);

            return Unit.Value;
        }
    }
}
