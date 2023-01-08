using CarRental.Application.Contracts.Persistence;
using CarRental.Application.Functions.CarAddresses.Exceptions;
using CarRental.Domain.Entities;
using MediatR;
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
        public DeleteCarAddressCommandHandler(IAsyncRepository<CarAddress> carAddressRepository)
        {
            _carAddressRepository= carAddressRepository;
        }

        public async Task<Unit> Handle(DeleteCarAddressCommand request, CancellationToken cancellationToken)
        {
            var carAddress = await _carAddressRepository.GetByIdAsync(request.Id);

            if (carAddress == null)
            {
                throw new CarAddressNotFoundException();
            }

            await _carAddressRepository.DeleteAsync(carAddress);

            return Unit.Value;
        }
    }
}
