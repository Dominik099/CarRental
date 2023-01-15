using CarRental.Application.Contracts.Persistence;
using CarRental.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Persistence.EF.Repositories
{
    public class RentalRepository : BaseRepository<Rental>, IRentalRepository
    {
        public RentalRepository(CarRentalContext dbContext) : base(dbContext)
        {

        }

        public async Task<Rental> GetByCarIdAsync(int id)
        {
            var rentedCar = await _dbContext.Rentals.Where(x => x.CarId == id).FirstOrDefaultAsync();

            return rentedCar;
        }
    }
}
