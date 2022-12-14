using Microsoft.EntityFrameworkCore;

namespace CarRental.Persistence.EF
{
    public class CarRentalContext : DbContext
    {
        public CarRentalContext(DbContextOptions<CarRentalContext> options) : base(options)
        {

        }


    }
}