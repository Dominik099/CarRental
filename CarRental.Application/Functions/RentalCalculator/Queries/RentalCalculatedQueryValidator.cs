using CarRental.Application.Contracts.Persistence;
using CarRental.Application.Functions.RentalCalculator.Exceptions;
using CarRental.Application.RentalCalculator;
using CarRental.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Functions.RentalCalculator.Queries
{
    public class RentalCalculatedQueryValidator : AbstractValidator<RentalCalculatedQuery>
    {
        private readonly ICarRepository _carRepository;

        public RentalCalculatedQueryValidator(ICarRepository carRepository)
        {
            _carRepository= carRepository;

            RuleFor(x => x.CarId)
                .NotEmpty()
                .WithMessage("You must select car")
                .NotNull();

            RuleFor(x => x.EstimatedKilometers)
                .NotEmpty()
                .WithMessage("You must enter estimated kilometers")
                .NotNull()
                .LessThan(10000)
                .WithMessage("The anticipated number of kilometres must be less than 10000")
                .GreaterThan(0)
                .WithMessage("The anticipated number of kilometres must be greater than 0");

            RuleFor(x => x.DriverLicenceDate)
                .NotEmpty()
                .WithMessage("You must enter the date of obtaining your driving license")
                .NotNull()
                .LessThan(DateTime.Now);
 

            RuleFor(x => x.RentalDate)
                .NotEmpty()
                .WithMessage("Yo must enter the date of rental car")
                .NotNull()
                .GreaterThan(DateTime.Now.Date)
                .WithMessage("The car can be rented from the next day");

            RuleFor(x => x.ReturnDate)
                .NotEmpty()
                .WithMessage("Yo must enter the date of return car")
                .NotNull()
                .GreaterThan(x => x.RentalDate.Date)
                .WithMessage("The return date must be greater than the rental date");

            RuleFor(x => x)
                .Must(DriverIsNotTooYoung)
                .WithMessage("You must have had a driving license for more than 3 years to rent a premium car");
        }

        private bool DriverIsNotTooYoung(RentalCalculatedQuery input)
        {
            var checkedLicense = _carRepository.DriverIsNotTooYoung(input.CarId, input.DriverLicenceDate);

            return checkedLicense;
        }
    }
}
