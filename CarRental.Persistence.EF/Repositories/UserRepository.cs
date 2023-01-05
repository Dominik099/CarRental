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

        public Task<bool> IsEmailAlreadyExist(string email)
        {
            var matches = _dbContext.Users
                .Any(x => x.Email.Equals(email));

            return Task.FromResult(matches);
        }
    }
}
