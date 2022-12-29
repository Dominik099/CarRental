using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using CarRental.Application.Functions.CarAddresses.Queries.GetCarAddressList;
using CarRental.Application.Functions.CarAddresses.Queries.GetCarAddressById;
using CarRental.Application.Functions.Cars.Queries.GetCarById;
using CarRental.Application.RentalCalculator;
using CarRental.Application.Contracts.Persistence;
using CarRental.Application.Functions.RentalCalculator.Queries;
using CarRental.Application.RentalCalculator;
using CarRental.Application.RentalCalculator.Exceptions;

namespace CarRental.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalCalculatorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RentalCalculatorController(IMediator mediator)
        {
            _mediator = mediator;  
        }

        [HttpGet(Name = "CarRentalCalculator")]
        public async Task<ActionResult<RentalCalculatedQueryResponse>> CalculatePrice([FromQuery] RentalCalculatedQuery rentalCalculatedQuery)
        {
            var calculatedCost = await _mediator.Send(rentalCalculatedQuery);

            return Ok(calculatedCost);
        }
    }
}
