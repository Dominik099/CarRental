using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
        public int YearOfProduction { get; set; }
        public string Engine { get; set; }
        public decimal AVGFuelConsumption { get; set; }
        public int NumberOfCars { get; set; }

        public CarAddress CarAddress { get; set; }
        public PriceCategory PriceCategory { get; set; }
    }
}
