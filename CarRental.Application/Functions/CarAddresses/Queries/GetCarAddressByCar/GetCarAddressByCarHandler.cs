using CarRental.Application.Contracts.Persistence;
using CarRental.Application.Functions.CarAddresses.Queries.GetCarAddressList;
using CarRental.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Functions.CarAddresses.Queries.GetCarAddressByCar
{
    public class GetCarAddressByCarHandler : IRequestHandler<GetCarAddressByCarQuery, List<CarAddressDto>>
    {
        private readonly ICarRepository _carRepository;
        private readonly ICarAddressRepository _carAddressRepository;

        public GetCarAddressByCarHandler(ICarRepository carRepository, ICarAddressRepository carAddressRepository)
        {
            _carRepository = carRepository;
            _carAddressRepository = carAddressRepository;
        }
        public async Task<List<CarAddressDto>> Handle(GetCarAddressByCarQuery request, CancellationToken cancellationToken)
        {
            var car = await _carRepository.GetByIdAsync(request.CarId);

            var addresses = await _carAddressRepository.GetCarAddressesAsync(car.Mark, car.Model);

            return addresses;
        }
    }
}
