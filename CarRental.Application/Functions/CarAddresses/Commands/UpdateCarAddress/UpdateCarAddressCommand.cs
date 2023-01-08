using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Functions.CarAddresses.Commands.UpdateCarAddress
{
    public class UpdateCarAddressCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
    }
}
