using CarRental.Application.Contracts.Persistence;
using CarRental.Application.RentalCalculator;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Functions.CarRental.Commands.CarRentedCommand
{
    public class CarRentalCommandValidator : AbstractValidator<CarRentalCommand>
    {
        private readonly ICarRepository _carRepository;

        public CarRentalCommandValidator(ICarRepository carRepository)
        {
            _carRepository = carRepository;

            RuleFor(x => x.CarId)
                .NotEmpty()
                .WithMessage("You must select car")
                .NotNull();

            RuleFor(x => x.DriverLicenseDate)
                .NotEmpty()
                .WithMessage("You must enter the date of obtaining your driving license")
                .NotNull()
                .LessThan(DateTime.Now);

            RuleFor(x => x.RentDate)
                .NotEmpty()
                .WithMessage("Yo must enter the date of rental car")
                .NotNull()
                .GreaterThan(DateTime.Now.Date)
                .WithMessage("The car can be rented from the next day");

            RuleFor(x => x.ReturnDate)
                .NotEmpty()
                .WithMessage("Yo must enter the date of return car")
                .NotNull()
                .GreaterThan(x => x.RentDate.Date)
                .WithMessage("The return date must be greater than the rental date");

            RuleFor(x => x)
                .Must(DriverIsNotTooYoung)
                .WithMessage("You must have had a driving license for more than 3 years to rent a premium car");
        }

        private bool DriverIsNotTooYoung(CarRentalCommand input)
        {
            var checkedLicense = _carRepository.DriverIsNotTooYoung(input.CarId, input.DriverLicenseDate);

            return checkedLicense;
        }
    }
}
