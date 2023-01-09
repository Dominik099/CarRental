using CarRental.Application.Contracts.Persistence;
using CarRental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Persistence.EF.Repositories
{
    public class PriceCategoryRepository : BaseRepository<PriceCategory>, IPriceCategoryRepository
    {
        public PriceCategoryRepository(CarRentalContext dbContext) : base(dbContext)
        {

        }

        public bool IsPriceCategoryExist(int priceCategoryId)
        {
            var priceCategoryExist = _dbContext.PriceCategories.Any(x => x.Id == priceCategoryId);

            return priceCategoryExist;
        }
    }
}
