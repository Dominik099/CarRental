using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Functions.Cars.Commands.DeleteCar
{
    public class DeleteCarCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public ClaimsPrincipal User { get; set; }
    }
}
