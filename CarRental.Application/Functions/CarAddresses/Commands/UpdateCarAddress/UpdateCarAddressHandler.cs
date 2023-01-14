using AutoMapper;
using CarRental.Application.Authorization.AuthorizationByCarAddressOwner;
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

namespace CarRental.Application.Functions.CarAddresses.Commands.UpdateCarAddress
{
    public class UpdateCarAddressHandler : IRequestHandler<UpdateCarAddressCommand>
    {
        private readonly IAsyncRepository<CarAddress> _carAddressRepository;
        private readonly IAuthorizationService _authorizationService;

        public UpdateCarAddressHandler(IAsyncRepository<CarAddress> carAddressRepository, IAuthorizationService authorizationService)
        {
            _carAddressRepository= carAddressRepository;
            _authorizationService= authorizationService;
        }

        public async Task<Unit> Handle(UpdateCarAddressCommand request, CancellationToken cancellationToken)
        {
            var carAddress = await _carAddressRepository.GetByIdAsync(request.Id);

            if (carAddress is null)
            {
                throw new CarAddressNotFoundException();
            }

           var authorizationResult = _authorizationService.AuthorizeAsync(request.User, carAddress, 
                new ResourceOperationRequirement(ResourceOperation.Update)).Result;

            if(!authorizationResult.Succeeded)
            {
                throw new ForbidException();
            }

            carAddress.City = request.City;
            carAddress.Street = request.Street;
            carAddress.PostalCode = request.PostalCode;

            await _carAddressRepository.UpdateAsync(carAddress);

            return Unit.Value;
        }
    }
}
