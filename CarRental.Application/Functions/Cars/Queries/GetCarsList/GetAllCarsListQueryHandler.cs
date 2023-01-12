using CarRental.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Domain.Entities;
using AutoMapper;
using CarRental.Application.Functions.Cars;
using CarRental.Application.Functions.Cars.Queries.GetCarModelsCommon;

namespace CarRental.Application.Functions.Cars.Queries.GetCarsList
{
    public class GetAllCarsListQueryHandler : IRequestHandler<GetAllCarsListQuery, List<CarsDto>>
    {
        private readonly ICarRepository _carRepository;
        private readonly IAsyncRepository<PriceCategory> _priceCategoryRepository;
        private readonly IMapper _mapper;

        public GetAllCarsListQueryHandler (IMapper mapper, ICarRepository carRepository, IAsyncRepository<PriceCategory> priceCategoryRepository)
        {
            _mapper = mapper;
            _carRepository = carRepository;
            _priceCategoryRepository = priceCategoryRepository;
        }

        public async Task<List<CarsDto>> Handle(GetAllCarsListQuery request, CancellationToken cancellationToken)
        {
            var result = await _carRepository.GetCarsListAsync();

            return result;

        }
    }
}
