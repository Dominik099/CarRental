using AutoMapper;
using CarRental.Application.Contracts.Persistence;
using CarRental.Application.Functions.Cars.Queries.GetCarsList;
using CarRental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using CarRental.Application.Functions.RentalCalculator.Exceptions;

namespace CarRental.Application.Functions.Cars.Queries.GetCarById
{
    public class GetCarByIdQueryHandler : IRequestHandler<GetCarByIdQuery, CarDto>
    {
        private readonly IAsyncRepository<Car> _carRepository;
        private readonly IAsyncRepository<PriceCategory> _priceCategoryRepository;
        private readonly IMapper _mapper;

        public GetCarByIdQueryHandler(IMapper mapper, IAsyncRepository<Car> carRepository, IAsyncRepository<PriceCategory> priceCategoryRepository)
        {
            _mapper = mapper;
            _carRepository = carRepository;
            _priceCategoryRepository = priceCategoryRepository;
        }

        public async Task<CarDto> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
        {

            var car = await _carRepository.GetByIdAsync(request.Id);

            if (car is null)
            {
                throw new CarNotFoundException();
            }

            var carMapped = _mapper.Map<CarDto>(car);

            var priceCategory = await _priceCategoryRepository.GetByIdAsync(car.PriceCategoryId);

            carMapped.PriceCategory = _mapper.Map<PriceCategoryDto>(priceCategory);

            return carMapped;


        }
    }
}
