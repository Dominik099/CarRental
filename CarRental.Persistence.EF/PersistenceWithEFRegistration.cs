using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;


namespace CarRental.Persistence.EF
{
    public static class PersistenceWithEFRegistration
    {
        public static IServiceCollection AddCarRentalPersistenceEFServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CarRentalContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("CarRentalConnectionString")));

            return services;
        }
    }
}
