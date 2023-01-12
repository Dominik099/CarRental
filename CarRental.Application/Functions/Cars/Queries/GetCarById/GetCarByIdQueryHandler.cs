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
using CarRental.Application.Functions.Cars.Queries.GetCarModelsCommon;

namespace CarRental.Application.Functions.Cars.Queries.GetCarById
{
    public class GetCarByIdQueryHandler : IRequestHandler<GetCarByIdQuery, CarsDto>
    {
        private readonly ICarRepository _carRepository;

        public GetCarByIdQueryHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<CarsDto> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
        {

            var car = await _carRepository.GetByIdAsync(request.Id);

            if (car is null)
            {
                throw new CarNotFoundException();
            }

            var carDto = new CarsDto()
            {
                Mark = car.Mark,
                Model = car.Model,
            };

            return carDto;


        }
    }
}
