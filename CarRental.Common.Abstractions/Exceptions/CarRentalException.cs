using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Common.Abstractions.Exceptions
{
    public abstract class CarRentalException : Exception
    {
        protected CarRentalException(string message) : base(message) { }
    }

    public abstract class BadRequestException : CarRentalException
    {
        protected BadRequestException(string message) : base(message) { }
    }

    public abstract class NotFoundException : CarRentalException
    {
        protected NotFoundException(string message) : base(message) { }
    }
}
