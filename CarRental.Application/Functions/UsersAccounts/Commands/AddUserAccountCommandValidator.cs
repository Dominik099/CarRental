using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Application.Functions.UsersAccounts;
using CarRental.Application.Contracts.Persistence;
using CarRental.Domain.Entities;
using System.ComponentModel;

namespace CarRental.Application.Functions.UsersAccounts.Commands
{
    public class AddUserAccountCommandValidator : AbstractValidator<AddUserAccountCommand>
    {
        private readonly IUserRepository _userRepository;

        public AddUserAccountCommandValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            RuleFor(x => x.Email)
                .NotNull()
                .WithMessage("Email cannot be empty");

            RuleFor(x => x.FirstName)
                .NotNull()
                .WithMessage("First name cannot be empty")
                .MaximumLength(20)
                .WithMessage("First name is too long");

            RuleFor(x => x.LastName)
                .NotNull()
                .WithMessage("Last name cannot be empty")
                .MaximumLength(30)
                .WithMessage("Last name is too long");

            RuleFor(x => x.Password)
                .NotNull()
                .WithMessage("Password cannot be empty")
                .MinimumLength(6)
                .WithMessage("Password must be at least 6 characters long");

            RuleFor(x => x.Pesel)
                .NotNull()
                .WithMessage("Pesel cannot be empty")
                .Length(11)
                .WithMessage("Pesel must have 11 characters");

            RuleFor(x => x)
                .Must(UserIsAdult)
                .WithMessage("You must be of legal age to rent a car");

            RuleFor(x => x)
                .Must(DrivingLicenceCheck)
                .WithMessage("You must be of legal age to hold a driver's license");

            RuleFor(x => x)
                .MustAsync(IsPeselAlreadyExist)
                .WithMessage("User with the given PESEL already exists");
        }

        private bool UserIsAdult(AddUserAccountCommand arg)
        {
            var daysOfEighteenYears = 6570;
            var isAdult = true;

            var userAge = (DateTime.UtcNow - arg.DateOfBirth).TotalDays < (daysOfEighteenYears + 1);

            if (userAge)
            {
                isAdult = false;
            }

            return isAdult;
        }

        private bool DrivingLicenceCheck(AddUserAccountCommand arg)
        {
            var daysOfEighteenYears = 6570;
            var driverLicense = true;

            var driverLicenseTime = (arg.DriverLicenseDate - arg.DateOfBirth).TotalDays < (daysOfEighteenYears + 1);

            if (driverLicenseTime || arg.DriverLicenseDate < arg.DateOfBirth)
            {
                driverLicense = false;
            }

            return driverLicense;
        }

        private async Task<bool> IsPeselAlreadyExist(AddUserAccountCommand user, CancellationToken cancellationToken)
        {
            var check = await _userRepository
                .IsPeselAlreadyExist(user.Pesel);

            return !check;
        }
    }
}
