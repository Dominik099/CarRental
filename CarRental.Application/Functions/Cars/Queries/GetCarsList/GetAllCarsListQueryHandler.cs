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

namespace CarRental.Application.Functions.Cars.Queries.GetCarsList
{
    public class GetAllCarsListQueryHandler : IRequestHandler<GetAllCarsListQuery, List<CarDto>>
    {
        private readonly IAsyncRepository<Car> _carRepository;
        private readonly IAsyncRepository<PriceCategory> _priceCategoryRepository;
        private readonly IMapper _mapper;

        public GetAllCarsListQueryHandler (IMapper mapper, IAsyncRepository<Car> carRepository, IAsyncRepository<PriceCategory> priceCategoryRepository)
        {
            _mapper = mapper;
            _carRepository = carRepository;
            _priceCategoryRepository = priceCategoryRepository;
        }

        public async Task<List<CarDto>> Handle(GetAllCarsListQuery request, CancellationToken cancellationToken)
        {

            var cars = await _carRepository.GetAllAsync();
            var carsList = _mapper.Map<List<CarDto>>(cars);
            var priceCategory = await _priceCategoryRepository.GetAllAsync();
            foreach(var x in cars)
            {
                foreach (var car in carsList)
                {
                    foreach (var category in priceCategory)
                    {
                        if (x.Id == car.Id && x.PriceCategoryId == category.Id)
                        {
                            car.PriceCategory = _mapper.Map<PriceCategoryDto>(category);
                        }
                    }
                }
            }

            //carsList.DistinctBy(x => x.Model);
            return carsList;

        }
    }
}
