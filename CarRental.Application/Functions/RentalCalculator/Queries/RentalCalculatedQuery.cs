using CarRental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Application.Functions.Cars.Queries.GetCarsList;
using System.ComponentModel.DataAnnotations;
using MediatR;
using CarRental.Application.RentalCalculator;
using CarRental.Application.Functions.RentalCalculator.Exceptions;
using CarRental.Application.Functions.RentalCalculator.Queries;
using FluentValidation.Validators;

namespace CarRental.Application.RentalCalculator
{
    public class RentalCalculatedQuery : IRequest<RentalCalculatedQueryResponse>
    {
        public int CarId { get; set; }
        public int EstimatedKilometers { get; set; }
        public DateTime DriverLicenceDate { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }


}
