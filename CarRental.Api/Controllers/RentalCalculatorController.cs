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
        public async Task<ActionResult> CalculatePrice([FromQuery]int carId, [FromQuery]int kilometers, [FromQuery]DateTime driverLicenceDate,
            [FromQuery]DateTime rentalDate, [FromQuery]DateTime returnDate)
        {
            var selectedCar = await _mediator.Send(new GetCarByIdQuery() { Id = carId });
            var userInput = new UserInput(selectedCar, kilometers, driverLicenceDate, rentalDate, returnDate);
            

            return Ok(selectedCar);
        }

    }
}
