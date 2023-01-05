using AutoMapper;
using CarRental.Application.Contracts.Persistence;
using CarRental.Application.Functions.UsersAccounts.Exceptions;
using CarRental.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Functions.UsersAccounts.Commands
{
    public class AddUserAccountCommandHandler : IRequestHandler<AddUserAccountCommand, AddUserAccountCommandResponse>
    {
        private readonly IUserRepository _userRepository;

        public AddUserAccountCommandHandler(IUserRepository userRepository)
        {
            _userRepository= userRepository;
        }

        public async Task<AddUserAccountCommandResponse> Handle(AddUserAccountCommand command, CancellationToken cancellationToken)
        {
            var validator = new AddUserAccountCommandValidator(_userRepository);
            var validatorResult = await validator.ValidateAsync(command);

            if(!validatorResult.IsValid)
            {
                return new AddUserAccountCommandResponse(validatorResult);
            }

            var newUser = new User()
            {
                Email = command.Email,
                FirstName = command.FirstName,
                LastName = command.LastName,
                DateOfBirth = command.DateOfBirth,
                PasswordHash = command.Password,
                DriverLicenseDate = command.DriverLicenseDate,
                Pesel = command.Pesel,
                RoleId = 1,
            };

            newUser = await _userRepository.AddAsync(newUser);

            return new AddUserAccountCommandResponse(newUser.Id);
        }
    }
}
