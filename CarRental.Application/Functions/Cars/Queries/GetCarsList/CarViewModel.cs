using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Functions.Cars.Queries.GetCarsList
{
    public class CarViewModel
    {
        public int Id { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
        public int YearOfProduction { get; set; }
        public string Engine { get; set; }
        public decimal AVGFuelConsumption { get; set; }
        public int NumberOfCars { get; set; }
        public PriceCategoryDto Category { get; set; }
        public int CategoryId { get; set; }
    }
}
