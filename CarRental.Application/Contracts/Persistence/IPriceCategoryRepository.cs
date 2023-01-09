using CarRental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Contracts.Persistence
{
    public interface IPriceCategoryRepository : IAsyncRepository<PriceCategory>
    {
        bool IsPriceCategoryExist(int id);
    }
}
