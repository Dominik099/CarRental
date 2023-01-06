using CarRental.Common.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Functions.UsersAccounts.Exceptions
{
    public class InvalidEmailOrPasswordException : BadRequestException
    {
        public InvalidEmailOrPasswordException() : base("Invalid email or password")
        {
        }
    }
}
