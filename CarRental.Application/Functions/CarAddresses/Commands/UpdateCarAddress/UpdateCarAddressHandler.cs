using AutoMapper;
using CarRental.Application.Contracts.Persistence;
using CarRental.Domain.Entities;
using MediatR;
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
        private readonly IMapper _mapper;

        public UpdateCarAddressHandler(IAsyncRepository<CarAddress> carAddressRepository, IMapper mapper)
        {
            _carAddressRepository= carAddressRepository;
            _mapper= mapper;
        }

        public async Task<Unit> Handle(UpdateCarAddressCommand request, CancellationToken cancellationToken)
        {
            var carAddress = _mapper.Map<CarAddress>(request);

            await _carAddressRepository.UpdateAsync(carAddress);

            return Unit.Value;
        }
    }
}
