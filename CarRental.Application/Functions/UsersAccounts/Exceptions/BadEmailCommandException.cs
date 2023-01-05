using CarRental.Common.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Functions.UsersAccounts.Exceptions
{
    public class BadEmailCommandException : BadRequestException
    {
        public BadEmailCommandException() : base("Email is invalid")
        {
        }
    }
}
