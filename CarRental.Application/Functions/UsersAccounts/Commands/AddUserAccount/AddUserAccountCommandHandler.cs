using AutoMapper;
using CarRental.Application.Contracts.Persistence;
using CarRental.Application.Functions.UsersAccounts.Exceptions;
using CarRental.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Functions.UsersAccounts.Commands.AddUserAccount
{
    public class AddUserAccountCommandHandler : IRequestHandler<AddUserAccountCommand, AddUserAccountCommandResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AddUserAccountCommandHandler(IUserRepository userRepository, IPasswordHasher<User> passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<AddUserAccountCommandResponse> Handle(AddUserAccountCommand command, CancellationToken cancellationToken)
        {

            var newUser = new User()
            {
                Email = command.Email,
                FirstName = command.FirstName,
                LastName = command.LastName,
                DateOfBirth = command.DateOfBirth,
                RoleId = 2,
            };

            var hashedPassword = _passwordHasher.HashPassword(newUser, command.Password);

            newUser.PasswordHash = hashedPassword;

            newUser = await _userRepository.AddAsync(newUser);

            return new AddUserAccountCommandResponse()
            {
                Id = newUser.Id
            };
        }
    }
}
