using CarRental.Common.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Functions.CarAddresses.Exceptions
{
    public class CarAddressNotFoundException : NotFoundException
    {
        public CarAddressNotFoundException() : base("Car address not found")
        {
        }
    }
}
