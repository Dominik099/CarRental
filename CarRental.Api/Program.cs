using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using CarRental.Persistence.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using MediatR;
using AutoMapper;
using Microsoft.AspNetCore.Cors.Infrastructure;
using CarRental.Application.Contracts.Persistence;
using CarRental.Application.Functions.Cars.Queries.GetCarsList;
using CarRental.Persistence.EF.Repositories;
using Microsoft.OpenApi.Models;
using CarRental.Application.Mapper;
using CarRental.Application.Functions.RentalCalculator;
using CarRental.Application.Middleware;
using Microsoft.AspNetCore.Identity;
using CarRental.Domain.Entities;
using System.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using CarRental.Application;
using CarRental.Application.RentalCalculator;
using CarRental.Application.Functions.RentalCalculator.Queries;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Diagnostics;
using CarRental.Application.Functions.Cars.Queries.GetCarById;
using CarRental.Application.Functions.UsersAccounts.Commands.AddUserAccount;
using CarRental.Application.Functions.UsersAccounts.Query.UserLogin;
using CarRental.Application.Functions.CarAddresses.Commands.AddCarAddress;
using CarRental.Application.Functions.CarAddresses.Commands.UpdateCarAddress;
using CarRental.Application.Functions.Cars.Commands.AddCar;

namespace CarRental.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            var authenticationSettings = new AuthenticationSettings();

            builder.Configuration.GetSection("Authentication").Bind(authenticationSettings);
            builder.Services.AddSingleton(authenticationSettings);
            builder.Services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = "Bearer";
                option.DefaultScheme = "Bearer";
                option.DefaultChallengeScheme = "Bearer";
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = authenticationSettings.JwtIssuer,
                    ValidAudience = authenticationSettings.JwtIssuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtKey)),
                };
            });

            builder.Services.AddControllers().AddFluentValidation();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "CarRental API",
                });

            });
            builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);
            builder.Services.AddDbContext<CarRentalContext>(
                option => option
                .UseSqlServer(builder.Configuration.GetConnectionString("CarRentalConnectionString"))
                );
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            builder.Services.AddScoped<ICarRepository, CarRepository>();
            builder.Services.AddScoped<ICarAddressRepository, CarAddressRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ErrorHandlingMiddleware>();
            builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
            builder.Services.AddScoped<IValidator<RentalCalculatedQuery>, RentalCalculatedQueryValidator>();
            builder.Services.AddScoped<IValidator<AddUserAccountCommand>, AddUserAccountCommandValidator>();
            builder.Services.AddScoped<IValidator<UserLoginQuery>, UserLoginQueryValidator>();
            builder.Services.AddScoped<IValidator<AddCarAddressCommand>, AddCarAddressCommandValidator>();
            builder.Services.AddScoped<IValidator<UpdateCarAddressCommand>, UpdateCarAddressValidator>();
            builder.Services.AddScoped<IValidator<AddCarCommand>, AddCarCommandValidator>();

            var app = builder.Build();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            var mapper = config.CreateMapper();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware<ErrorHandlingMiddleware>();

            app.UseAuthentication();
            app.UseHttpsRedirection();

            using var scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetService<CarRentalContext>();

            var pendingMigrations = dbContext.Database.GetPendingMigrations();
            if (pendingMigrations.Any())
            {
                dbContext.Database.Migrate();
            }
            app.UseRouting();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}