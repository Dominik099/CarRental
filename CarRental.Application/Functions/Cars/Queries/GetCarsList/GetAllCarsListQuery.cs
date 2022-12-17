using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Functions.Cars.Queries.GetCarsList
{
    public class GetAllCarsListQuery : IRequest<List<CarViewModel>>
    {
    }
}
