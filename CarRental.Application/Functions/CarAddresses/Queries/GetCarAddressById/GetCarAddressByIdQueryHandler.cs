using AutoMapper;
using CarRental.Application.Contracts.Persistence;
using CarRental.Application.Functions.CarAddresses.Queries.GetCarAddressList;
using CarRental.Application.Functions.Cars.Queries.GetCarById;
using CarRental.Application.Functions.Cars.Queries.GetCarsList;
using CarRental.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Functions.CarAddresses.Queries.GetCarAddressById
{
    public class GetCarAddressByIdQueryHandler : IRequestHandler<GetCarAddressByIdQuery, CarAddressViewModel>
    {
        private readonly IAsyncRepository<CarAddress> _carAddressRepository;
        private readonly IMapper _mapper;

        public GetCarAddressByIdQueryHandler(IAsyncRepository<CarAddress> carAddressRepository, IMapper mapper)
        {
            _carAddressRepository = carAddressRepository;
            _mapper = mapper;
        }

        public async Task<CarAddressViewModel> Handle(GetCarAddressByIdQuery request, CancellationToken cancellation)
        {
            var carAddressById = await _carAddressRepository.GetByIdAsync(request.Id);

            return _mapper.Map<CarAddressViewModel>(carAddressById);
        }
    }
}
