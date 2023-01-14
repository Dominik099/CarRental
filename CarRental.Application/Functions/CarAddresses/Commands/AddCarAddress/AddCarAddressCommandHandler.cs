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

        public AddCarAddressCommandHandler(IAsyncRepository<CarAddress> carAddressRepository)
        {
            _carAddressRepository = carAddressRepository;
        }
        public async Task<AddCarAddressCommandResponse> Handle(AddCarAddressCommand request, CancellationToken cancellationToken)
        {
            var newCarAddress = new CarAddress()
            {
                City = request.City,
                Street = request.Street,
                PostalCode = request.PostalCode,
            };

            newCarAddress.AddedById = request.UserId;

            newCarAddress = await _carAddressRepository.AddAsync(newCarAddress);

            return new AddCarAddressCommandResponse()
            {
                Id = newCarAddress.Id,
            };
        }
    }
}
