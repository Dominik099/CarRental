using CarRental.Application.Functions.CarRental.Commands.CarRentedCommand;
using CarRental.Application.Functions.CarRental.Commands.CarReturnedCommand;
using CarRental.Application.Functions.Cars.Commands.AddCar;
using CarRental.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarRentalsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarRentalsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("rent", Name = "RentCar")]
        [Authorize(Policy = "Atleast18")]
        public async Task<ActionResult> RentCar([FromQuery] CarRentalCommand carRental)
        {
            var rentedCar = await _mediator.Send(carRental);
            return Ok(rentedCar);
        }

        [HttpPost("return", Name = "ReturnCar")]
        public async Task<ActionResult> ReturnCar([FromQuery] CarReturnCommand carReturn)
        {
            var rentedCar = await _mediator.Send(carReturn);
            return Ok();
        }

    }
}
