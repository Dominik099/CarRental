using CarRental.Application.Functions.CarAddresses.Queries.GetCarAddressList;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Functions.CarAddresses.Queries.GetCarAddressById
{
    public class GetCarAddressByIdQuery : IRequest<CarAddressDto>
    {
        public int Id { get; set; }
    }
}
