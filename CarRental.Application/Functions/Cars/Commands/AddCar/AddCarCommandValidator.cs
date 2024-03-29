﻿using CarRental.Application.Contracts.Persistence;
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
        private readonly ICarAddressRepository _carAddressRepository;
        private readonly IPriceCategoryRepository _priceCategoryRepository;

        public AddCarCommandValidator(ICarAddressRepository carAddressRepository, IPriceCategoryRepository priceCategoryRepository)
        {
            _carAddressRepository= carAddressRepository;
            _priceCategoryRepository= priceCategoryRepository;

            RuleFor(x => x.Mark)
                .NotEmpty()
                .WithMessage("Mark must not be empty")
                .MaximumLength(20)
                .WithMessage("Too long mark name");

            RuleFor(x => x.Model)
                .NotEmpty()
                .WithMessage("Model must not be empty");

            RuleFor(x => x.AVGFuelConsumption)
                .NotEmpty()
                .WithMessage("Average fuel consumption must not be empty")
                .PrecisionScale(3, 1, false); ;

            RuleFor(x => x.CarAddressId)
                .NotEmpty()
                .WithMessage("Address must not be empty");               

            RuleFor(x => x.PriceCategoryId)
                .NotEmpty()
                .WithMessage("Price category must not be empty");

            RuleFor(x => x)
                .Must(IsAddressExist)
                .WithMessage("The address with the specified ID number does not exist");

            RuleFor(x => x)
                .Must(IsPriceCategoryExist)
                .WithMessage("The price category with the specified ID number does not exist");

            RuleFor(x => x.RegistrationNumber)
                .NotEmpty()
                .WithMessage("Registration number must not be empty")
                .MaximumLength(7);
                
        }

        private bool IsAddressExist(AddCarCommand car)
        {
            var result = _carAddressRepository.IsCarAddressExist(car.CarAddressId);

            return result;
        }

        private bool IsPriceCategoryExist(AddCarCommand priceCategory)
        {
            var result = _priceCategoryRepository.IsPriceCategoryExist(priceCategory.PriceCategoryId);

            return result;
        }
    }
}
