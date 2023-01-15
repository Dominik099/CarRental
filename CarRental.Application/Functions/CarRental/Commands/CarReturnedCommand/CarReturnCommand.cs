using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Functions.CarRental.Commands.CarReturnedCommand
{
    public class CarReturnCommand : IRequest<Unit>
    {
        public int CarId { get; set; }
        public CarReturnCommand()
        {

        }
    }
}
