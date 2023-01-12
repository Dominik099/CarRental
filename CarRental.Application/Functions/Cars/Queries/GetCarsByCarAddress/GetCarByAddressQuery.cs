using CarRental.Application.Functions.Cars.Queries.GetCarModelsCommon;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Functions.Cars.Queries.GetCarsByCarAddress
{
    public class GetCarByAddressQuery : IRequest<List<CarsDto>>
    {
        public int Id { get; set; }
    }
}
