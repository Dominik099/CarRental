using CarRental.Application.Contracts.Persistence;
using CarRental.Application.Functions.RentalCalculator.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Functions.Cars.Commands.DeleteCarGroup
{
    public class DeleteCarGroupHandler : IRequestHandler<DeleteCarGroupCommand, Unit>
    {
        private readonly ICarRepository _carRepository;
        public DeleteCarGroupHandler(ICarRepository carRepository)
        {
            _carRepository= carRepository;
        }

        public async Task<Unit> Handle(DeleteCarGroupCommand request, CancellationToken cancellationToken)
        {
            var car = await _carRepository.GetByIdAsync(request.Id);

            if (car == null)
            {
                throw new CarNotFoundException();
            }

            await _carRepository.DeleteAsync(car);

            return Unit.Value;
        }
    }
}
