using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain.Entities
{
    public class CarAddress
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public int? AddedById { get; set; }
        public virtual User AddedBy { get; set; }

        public List<Car> Cars { get; set; } = new List<Car>();
    }
}
