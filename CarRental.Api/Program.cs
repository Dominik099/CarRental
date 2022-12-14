using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using CarRental.Persistence.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;

namespace CarRental.Api
{
    public class Program
    {
        public static IConfiguration Configuration { get; set; }

        public Program(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCarRentalPersistenceEFServices(Configuration);

            var app = builder.Build();

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

            app.MapControllers();

            app.Run();
        }
    }
}