using CarRental.Common.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.RentalCalculator.Exceptions
{
    public class TooLongKilometersException : BadRequestException
    {
        public TooLongKilometersException() : base("Invalid kilometers data")
        {
        }
    }
}
