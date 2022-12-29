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

namespace CarRental.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
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
            builder.Services.AddDbContext<CarRentalContext>(
                option => option
                .UseSqlServer(builder.Configuration.GetConnectionString("CarRentalConnectionString"))
                );
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            builder.Services.AddScoped<ICarRepository, CarRepository>();
            //builder.Services.AddScoped<IRentalCalculator, RentalCalculatedQueryHandler>();

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

            app.UseHttpsRedirection();

            app.UseAuthorization();

            using var scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetService<CarRentalContext>();

            var pendingMigrations = dbContext.Database.GetPendingMigrations();
            if (pendingMigrations.Any())
            {
                dbContext.Database.Migrate();
            }

            app.MapControllers();

            app.Run();
        }
    }
}