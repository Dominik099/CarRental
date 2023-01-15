using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Functions.Cars.Commands.AddCar
{
    public class AddCarCommand : IRequest<Unit>
    {
        public string Mark { get; set; }
        public string Model { get; set; }
        public decimal AVGFuelConsumption { get; set; }
        public string RegistrationNumber { get; set; }

        public int CarAddressId { get; set; }
        public int PriceCategoryId { get; set; }
        //public ClaimsPrincipal User { get; set; }
    }
}
