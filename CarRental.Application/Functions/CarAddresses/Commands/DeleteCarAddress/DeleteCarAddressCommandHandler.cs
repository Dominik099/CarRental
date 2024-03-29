﻿using CarRental.Application.Authorization;
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

namespace CarRental.Application.Functions.CarAddresses.Commands.DeleteCarAddress
{
    public class DeleteCarAddressCommandHandler : IRequestHandler<DeleteCarAddressCommand>
    {
        private readonly IAsyncRepository<CarAddress> _carAddressRepository;
        private readonly IAuthorizationService _authorizationService;
        private readonly IUserContext _userContext;
        public DeleteCarAddressCommandHandler(IAsyncRepository<CarAddress> carAddressRepository, IAuthorizationService authorizationService, IUserContext userContext)
        {
            _carAddressRepository = carAddressRepository;
            _authorizationService = authorizationService;
            _userContext = userContext;
        }

        public async Task<Unit> Handle(DeleteCarAddressCommand request, CancellationToken cancellationToken)
        {
            var carAddress = await _carAddressRepository.GetByIdAsync(request.Id);

            if (carAddress == null)
            {
                throw new CarAddressNotFoundException();
            }

            var authorizationResult = _authorizationService.AuthorizeAsync(_userContext.User, carAddress,
                new ResourceOperationRequirement(ResourceOperation.Delete)).Result;

            if (!authorizationResult.Succeeded)
            {
                throw new ForbidException();
            }

            await _carAddressRepository.DeleteAsync(carAddress);

            return Unit.Value;
        }
    }
}
