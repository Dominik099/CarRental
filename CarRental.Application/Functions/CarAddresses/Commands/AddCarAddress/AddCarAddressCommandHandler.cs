using CarRental.Application.Authorization;
using CarRental.Application.Contracts.Persistence;
using CarRental.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Functions.CarAddresses.Commands.AddCarAddress
{
    public class AddCarAddressCommandHandler : IRequestHandler<AddCarAddressCommand, AddCarAddressCommandResponse>
    {
        private readonly IAsyncRepository<CarAddress> _carAddressRepository;
        private readonly IUserContext _userContext;

        public AddCarAddressCommandHandler(IAsyncRepository<CarAddress> carAddressRepository, IUserContext userContext)
        {
            _carAddressRepository = carAddressRepository;
            _userContext= userContext;
        }
        public async Task<AddCarAddressCommandResponse> Handle(AddCarAddressCommand request, CancellationToken cancellationToken)
        {
            var newCarAddress = new CarAddress()
            {
                City = request.City,
                Street = request.Street,
                PostalCode = request.PostalCode,
            };

            newCarAddress.AddedById = _userContext.GetUserId;

            newCarAddress = await _carAddressRepository.AddAsync(newCarAddress);

            return new AddCarAddressCommandResponse()
            {
                Id = newCarAddress.Id,
            };
        }
    }
}
