using CarRental.Application.Contracts.Persistence;
using CarRental.Application.Functions.CarAddresses.Commands.AddCarAddress;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Functions.CarAddresses.Commands.UpdateCarAddress
{
    public class UpdateCarAddressValidator : AbstractValidator<UpdateCarAddressCommand>
    {
        private readonly ICarAddressRepository _carAddressRepository;

        public UpdateCarAddressValidator(ICarAddressRepository carAddressRepository)
        {
            _carAddressRepository = carAddressRepository;

            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id cannot be empty");  

            RuleFor(x => x.City)
                //.NotEmpty()
                //.WithMessage("You must enter city name")
                .MaximumLength(20)
                .WithMessage("City name is too long");

            RuleFor(x => x.Street)
                //.NotEmpty()
                //.WithMessage("You must enter street name")
                .MaximumLength(30)
                .WithMessage("Street name is too long");

            RuleFor(x => x.PostalCode)
                //.NotEmpty()
                //.WithMessage("You must enter postal code")
                .Length(6)
                .WithMessage("Invalid postal code");

            RuleFor(x => x)
                .Must(IsCityOrStreetAlreadyExist)
                .WithMessage("Address is already exist");
        }

        private bool IsCityOrStreetAlreadyExist(UpdateCarAddressCommand updateCarAddress)
        {
            var check = _carAddressRepository.CityAndStreetAlreadyExist(updateCarAddress.City, updateCarAddress.Street);

            return !check;
        }
    }
}
