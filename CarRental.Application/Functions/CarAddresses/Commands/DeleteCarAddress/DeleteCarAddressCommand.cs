using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Functions.CarAddresses.Commands.DeleteCarAddress
{
    public class DeleteCarAddressCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
