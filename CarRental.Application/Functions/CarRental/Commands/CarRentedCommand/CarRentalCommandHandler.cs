using CarRental.Application.Authorization;
using CarRental.Application.Contracts.Persistence;
using CarRental.Application.Functions.RentalCalculator.Exceptions;
using CarRental.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Functions.CarRental.Commands.CarRentedCommand
{
    public class CarRentalCommandHandler : IRequestHandler<CarRentalCommand, CarRentalCommandResponse>
    {
        private readonly IAsyncRepository<Rental> _repository;
        private readonly ICarRepository _carRepository;
        private readonly IUserContext _userContext;

        public CarRentalCommandHandler(IAsyncRepository<Rental> repository, ICarRepository carRepository,
            IUserContext userContext)
        {
            _repository = repository;
            _carRepository = carRepository;
            _userContext = userContext;
        }
        public async Task<CarRentalCommandResponse> Handle(CarRentalCommand request, CancellationToken cancellationToken)
        {
            var car = await _carRepository.GetByIdAsync(request.CarId);

            if (car == null)
            {
                throw new CarNotFoundException();
            }

            var carRent = new Rental()
            {
                CarId = request.CarId,
                RentDate = request.RentDate,
                ReturnDate = request.ReturnDate,
            };
            carRent.UserId = (int)_userContext.GetUserId;

            car.IsAvailable = false;

            carRent = await _repository.AddAsync(carRent);
            await _carRepository.UpdateAsync(car);

            return new CarRentalCommandResponse()
            {
                Message = $"You rented a car {car.Mark} {car.Model} from {carRent.RentDate} to {carRent.ReturnDate}"
            };
        }
    }
}
