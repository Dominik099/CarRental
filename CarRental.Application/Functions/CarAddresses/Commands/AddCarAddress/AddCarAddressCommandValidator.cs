using CarRental.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Functions.CarAddresses.Commands.AddCarAddress
{
    public class AddCarAddressCommandValidator : AbstractValidator<AddCarAddressCommand>
    {
        private readonly ICarAddressRepository _carAddressRepository;

        public AddCarAddressCommandValidator(ICarAddressRepository carAddressRepository)
        {
            _carAddressRepository = carAddressRepository;

            RuleFor(x => x.City)
                .NotEmpty()
                .WithMessage("You must enter city name")
                .MaximumLength(20)
                .WithMessage("City name is too long");

            RuleFor(x => x.Street)
                .NotEmpty()
                .WithMessage("You must enter street name")
                .MaximumLength(30)
                .WithMessage("Street name is too long");

            RuleFor(x => x.PostalCode)
                .NotEmpty()
                .WithMessage("You must enter postal code")
                .Length(6)
                .WithMessage("Invalid postal code");

            RuleFor(x => x)
                .Must(IsCityOrStreetAlreadyExist)
                .WithMessage("Address is already exist");
        }

        private bool IsCityOrStreetAlreadyExist(AddCarAddressCommand carAddress)
        {
            var check = _carAddressRepository.CityAndStreetAlreadyExist(carAddress.City, carAddress.Street);

            return !check;
        }
    }
}
