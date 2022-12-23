using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Common.Abstractions;
using CarRental.Common.Abstractions.Exceptions;

namespace CarRental.Application.RentalCalculator.Exceptions
{
    public class TooYoungDriverException : BadRequestException
    {
        public TooYoungDriverException() : base("You are too young driver for premium cars")
        {
        }
    }
}
