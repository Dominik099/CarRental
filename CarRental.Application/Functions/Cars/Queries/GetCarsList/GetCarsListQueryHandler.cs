using CarRental.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Domain.Entities;
using AutoMapper;

namespace CarRental.Application.Functions.Cars.Queries.GetCarsList
{
    public class GetCarsListQueryHandler : IRequestHandler<GetCarsListQuery, List<CarViewModel>>
    {
        private readonly IAsyncRepository<Car> _carRepository;
        private readonly IAsyncRepository<PriceCategory> _priceCategoryRepository;
        private readonly IMapper _mapper;

        public GetCarsListQueryHandler (IMapper mapper, IAsyncRepository<Car> carRepository, IAsyncRepository<PriceCategory> priceCategoryRepository)
        {
            _mapper = mapper;
            _carRepository = carRepository;
            _priceCategoryRepository = priceCategoryRepository;
        }

        public async Task<List<CarViewModel>> Handle(GetCarsListQuery request, CancellationToken cancellationToken)
        {
            var cars = await _carRepository.GetAllAsync();
            var carsList = _mapper.Map<List<CarViewModel>>(cars);

            var priceCategory = await _priceCategoryRepository.GetAllAsync();

            carsList.Category = _mapper.Map<PriceCategoryDto>(priceCategory);

            return carsList;

        }
    }
}
