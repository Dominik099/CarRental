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

namespace CarRental.Application.Functions.UsersAccounts.Commands.AddUserAccount
{
    public class AddUserAccountCommandValidator : AbstractValidator<AddUserAccountCommand>
    {
        private readonly IUserRepository _userRepository;

        public AddUserAccountCommandValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            RuleFor(x => x.Email)
                .NotNull()
                .WithMessage("Email cannot be empty")
                .EmailAddress();

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

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty()
                .WithMessage("You must confirm your password")
                .Equal(x => x.Password)
                .WithMessage("Incorrect confirmation password");

            RuleFor(x => x)
                .Must(IsEmailAlreadyExist)
                .WithMessage("User with the given email already exists");

            RuleFor(x => x)
                .Must(DateOfBirthCheck)
                .WithMessage("Invalid date of birth");
        }

        private bool DateOfBirthCheck (AddUserAccountCommand arg)
        {
            var dateChecked = true;
            if(arg.DateOfBirth >= DateTime.UtcNow)
            {
                dateChecked = false;
            }
            return dateChecked;
        }

        private bool IsEmailAlreadyExist(AddUserAccountCommand user)
        {
            var check =  _userRepository
                .IsEmailAlreadyExist(user.Email);

            return !check;
        }
    }
}
