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
using CarRental.Api;
using System.IdentityModel.Tokens.Jwt;
using System.Collections;

namespace CarRental.Application.Functions.UsersAccounts.Query.UserLogin
{
    public class UserLoginQueryHandler : IRequestHandler<UserLoginQuery, UserLoginQueryResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAsyncRepository<Role> _roleRepository;
        private readonly AuthenticationSettings _authenticationSettings;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IMapper _mapper;

        public UserLoginQueryHandler(IUserRepository userRepository, IPasswordHasher<User> passwordHasher, IMapper mapper,
            IAsyncRepository<Role> roleRepository, AuthenticationSettings authenticationSettings)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _mapper = mapper;
            _roleRepository = roleRepository;
            _authenticationSettings = authenticationSettings;
        }

        public async Task<UserLoginQueryResponse> Handle(UserLoginQuery request, CancellationToken cancellationToken)
        {
            var validator = new UserLoginQueryValidator();
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid)
            {
                return new UserLoginQueryResponse(validatorResult);
            }

            var user = await _userRepository.GetByEmailAsync(request.Email);
            var userMapped = _mapper.Map<UserLoginResponse>(user);

            //var role = await _roleRepository.GetByIdAsync(user.RoleId);
            //userMapped.Role = _mapper.Map<Role>(role);
            userMapped.Role = await _roleRepository.GetByIdAsync(user.RoleId);

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
                new Claim(ClaimTypes.NameIdentifier, userMapped.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{userMapped.FirstName} {userMapped.LastName}"),
                new Claim(ClaimTypes.Role, $"{userMapped.Role.Name}"),
                new Claim("DateOfBirth", userMapped.DateOfBirth.Value.ToString("yyyy-MM-dd"))

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

            var resultToken = new UserLoginQueryResponse(tokenHandler.WriteToken(token));

            return resultToken;
        }
    }
}
