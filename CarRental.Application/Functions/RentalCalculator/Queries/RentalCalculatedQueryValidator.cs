using CarRental.Application.Contracts.Persistence;
using CarRental.Application.RentalCalculator;
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
                .GreaterThan(0);

            RuleFor(x => x.DriverLicenceDate)
                .NotEmpty()
                .WithMessage("You must enter the date of obtaining your driving license")
                .NotNull()
                .LessThan(DateTime.Now.AddDays(1));

            RuleFor(x => x.RentalDate)
                .NotEmpty()
                .WithMessage("Yo must enter the date of rental car")
                .NotNull()
                .GreaterThan(DateTime.Now.Date);

            RuleFor(x => x.ReturnDate)
                .NotEmpty()
                .WithMessage("Yo must enter the date of return car")
                .NotNull()
                .GreaterThan(x => x.RentalDate.Date)
                .WithMessage("The return date must be greater than the rental date");

            RuleFor(x => x)
                .MustAsync(DriverIsNotTooYoung)
                .WithMessage("You must have had a driving license for more than 3 years to rent a premium car");
        }

        private async Task<bool> DriverIsNotTooYoung(RentalCalculatedQuery input, CancellationToken cancellationToken)
        {
            var checkedLicense = await _carRepository.DriverIsNotTooYoung(input.CarId, input.DriverLicenceDate);

            return checkedLicense;
        }
    }
}
