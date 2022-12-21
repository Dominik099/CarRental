﻿using CarRental.Common.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Persistence.EF.Repositories.Exceptions
{
    public class TooLongKilometersException : BadRequestException
    {
        public TooLongKilometersException() : base("Invalid kilometers data")
        {
        }
    }
}
