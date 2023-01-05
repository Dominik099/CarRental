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
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(CarRentalContext dbContext) : base(dbContext)
        {
        }

        public Task<bool> IsPeselAlreadyExist(string pesel)
        {
            var matches = _dbContext.Users
                .Any(x => x.Pesel.Equals(pesel));

            return Task.FromResult(matches);
        }
    }
}
