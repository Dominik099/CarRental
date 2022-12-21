using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Contracts.Persistence
{
    public interface IRentalCalculator
    {
        public decimal CalculateForPeriod(DateTime rentalDate, DateTime returnDate); 
    }
}
