using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain.Entities
{
    public class PriceCategory
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public decimal Multiplier { get; set; }

        public List<Car> Cars { get; set; } = new List<Car>();
    }
}
