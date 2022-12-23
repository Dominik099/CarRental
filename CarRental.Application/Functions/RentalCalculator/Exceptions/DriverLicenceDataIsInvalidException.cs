using CarRental.Common.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.RentalCalculator.Exceptions
{
    public class DriverLicenceDataIsInvalidException : BadRequestException
    {
        public DriverLicenceDataIsInvalidException() : base("Driver licence data is invalid")
        {
        }
    }
}
