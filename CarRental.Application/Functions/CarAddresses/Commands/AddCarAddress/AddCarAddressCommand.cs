using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Functions.CarAddresses.Commands.AddCarAddress
{
    public class AddCarAddressCommand : IRequest<AddCarAddressCommandResponse>
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
    }
}
