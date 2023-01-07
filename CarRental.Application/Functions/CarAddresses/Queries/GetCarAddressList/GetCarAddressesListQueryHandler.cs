using CarRental.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Domain.Entities;
using AutoMapper;

namespace CarRental.Application.Functions.CarAddresses.Queries.GetCarAddressList
{
    public class GetCarAddressesListQueryHandler : IRequestHandler<GetCarAddressesListQuery, List<CarAddressDto>>
    {
        private readonly IAsyncRepository<CarAddress> _carAddressRepository;
        private readonly IMapper _mapper;

        public GetCarAddressesListQueryHandler(IAsyncRepository<CarAddress> carAddressRepository, IMapper mapper)
        {
            _carAddressRepository = carAddressRepository;
            _mapper = mapper;
        }

        public async Task<List<CarAddressDto>> Handle(GetCarAddressesListQuery request, CancellationToken cancellation)
        {
            var carAddressList = await _carAddressRepository.GetAllAsync();
            var carAddressListOrdered = carAddressList.OrderBy(x => x.City);

            return _mapper.Map<List<CarAddressDto>>(carAddressList).ToList();
        }
    } 
}
