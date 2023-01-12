using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Application.Functions.Cars;
using CarRental.Application.Functions.Cars.Queries.GetCarsList;
using CarRental.Application.Functions.Cars.Queries.GetCarModelsCommon;

namespace CarRental.Application.Functions.Cars.Queries.GetCarById
{
    public class GetCarByIdQuery : IRequest<CarsDto>
    {
        public int Id { get; set; }
    }
}
