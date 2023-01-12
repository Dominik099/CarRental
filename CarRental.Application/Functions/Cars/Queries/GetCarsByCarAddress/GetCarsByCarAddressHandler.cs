using CarRental.Application.Contracts.Persistence;
using CarRental.Application.Functions.Cars.Queries.GetCarModelsCommon;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Functions.Cars.Queries.GetCarsByCarAddress
{
    public class GetCarsByCarAddressHandler : IRequestHandler<GetCarByAddressQuery, List<CarsDto>>
    {
        private readonly ICarRepository _carRepository;

        public GetCarsByCarAddressHandler(ICarRepository carRepository)
        {
            _carRepository= carRepository;
        }
        public async Task<List<CarsDto>> Handle(GetCarByAddressQuery request, CancellationToken cancellationToken)
        {
            var result = await _carRepository.GetCarsByCarAddressAsync(request.Id);

            return result;
        }
    }
}
