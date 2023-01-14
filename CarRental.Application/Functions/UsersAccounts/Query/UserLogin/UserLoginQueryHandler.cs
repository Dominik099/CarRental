using CarRental.Application.Contracts.Persistence;
using CarRental.Application.Functions.UsersAccounts.Commands.AddUserAccount;
using CarRental.Application.Functions.UsersAccounts.Exceptions;
using CarRental.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Application.Functions.UsersAccounts.Exceptions;
using System.Security.Claims;
using CarRental.Application.Functions.Cars.Queries.GetCarsList;
using System.Runtime.ConstrainedExecution;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using CarRental.Application;
using System.Collections;

namespace CarRental.Application.Functions.UsersAccounts.Query.UserLogin
{
    public class UserLoginQueryHandler : IRequestHandler<UserLoginQuery, UserLoginQueryResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly AuthenticationSettings _authenticationSettings;
        private readonly IPasswordHasher<User> _passwordHasher;

        public UserLoginQueryHandler(IUserRepository userRepository, IPasswordHasher<User> passwordHasher,
            IAsyncRepository<Role> roleRepository, AuthenticationSettings authenticationSettings)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _authenticationSettings = authenticationSettings;
        }

        public async Task<UserLoginQueryResponse> Handle(UserLoginQuery request, CancellationToken cancellationToken)
        {

            var user = await _userRepository.GetByEmailAsync(request.Email);

            if (user is null)
            {
                throw new InvalidEmailOrPasswordException();
            }

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash ,request.Password);

            if (result == PasswordVerificationResult.Failed)
            {
                throw new InvalidEmailOrPasswordException();
            }

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.Role, $"{user.Role.Name}"),
                new Claim("DateOfBirth", user.DateOfBirth.Value.ToString("yyyy-MM-dd"))

            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);

            var token = new JwtSecurityToken(_authenticationSettings.JwtIssuer,
                _authenticationSettings.JwtIssuer,
                claims,
                expires: expires,
                signingCredentials: cred);

            var tokenHandler = new JwtSecurityTokenHandler();

            var resultToken = new UserLoginQueryResponse()
            {
                Token = tokenHandler.WriteToken(token)
            };

            return resultToken;
        }
    }
}
