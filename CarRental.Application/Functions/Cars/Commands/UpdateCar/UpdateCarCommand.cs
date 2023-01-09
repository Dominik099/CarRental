using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Functions.Cars.Commands.UpdateCar
{
    public class UpdateCarCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
        public int YearOfProduction { get; set; }
        public decimal EngineCapacity { get; set; }
        public int EnginePower { get; set; }
        public decimal AVGFuelConsumption { get; set; }
        public int CarAddressId { get; set; }
        public int PriceCategoryId { get; set; }
    }
}
