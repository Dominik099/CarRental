using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Functions.Cars.Commands.AddCar
{
    public class AddCarCommandValidator : AbstractValidator<AddCarCommand>
    {
        public AddCarCommandValidator()
        {
            RuleFor(x => x.Mark)
                .NotEmpty()
                .WithMessage("Mark cannot be empty");

            RuleFor(x => x.Model)
                .NotEmpty()
                .WithMessage("Model cannot be empty");

            RuleFor(x => x.YearOfProduction)
                .NotEmpty()
                .WithMessage("Year of production cannot be empty");

            RuleFor(x => x)
                .Must(InvalidYearOfProduction)
                .WithMessage("Invalid year of production");

            RuleFor(x => x.EngineCapacity)
                .NotEmpty()
                .WithMessage("Engine cannot be empty");

            RuleFor(x => x.AVGFuelConsumption)
                .NotEmpty()
                .WithMessage("Average fuel consumption cannot be empty");

            RuleFor(x => x.CarAddressId)
                .NotEmpty()
                .WithMessage("Address cannot be empty");

            RuleFor(x => x.PriceCategoryId)
                .NotEmpty()
                .WithMessage("Price category cannot be empty");
        }

        private bool InvalidYearOfProduction(AddCarCommand car)
        {
            if (car.YearOfProduction > DateTime.Now.Year)
            {
                return false;
            }

            return true;
        }
    }
}
