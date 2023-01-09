using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Functions.Cars.Commands.DeleteCarGroup
{
    public class DeleteCarGroupCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
