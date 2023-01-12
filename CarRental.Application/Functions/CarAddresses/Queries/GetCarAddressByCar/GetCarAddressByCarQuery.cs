using CarRental.Application.Functions.CarAddresses.Queries.GetCarAddressList;
using CarRental.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Functions.CarAddresses.Queries.GetCarAddressByCar
{
    public class GetCarAddressByCarQuery : IRequest<List<CarAddressDto>>
    {
        public int CarId { get; set; }
    }
}
