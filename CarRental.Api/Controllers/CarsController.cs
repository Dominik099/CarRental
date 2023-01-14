using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarRental.Application.Functions.Cars.Queries.GetCarsList;
using CarRental.Application.Functions.CarAddresses.Queries.GetCarAddressList;
using CarRental.Application.Functions.Cars.Queries.GetCarById;
using Microsoft.AspNetCore.Authorization;
using CarRental.Application.Functions.Cars.Commands.AddCar;
using CarRental.Application.Functions.Cars.Commands.DeleteCar;
using CarRental.Application.Functions.Cars.Commands.UpdateCar;
using CarRental.Application.Functions.Cars.Queries.GetCarModelsCommon;
using CarRental.Application.Functions.Cars.Queries.GetCarsByCarAddress;

namespace CarRental.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllCars")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<ActionResult<List<CarsDto>>> GetAllCars()
        {
            var carList = await _mediator.Send(new GetAllCarsListQuery());
            return Ok(carList);
        }

        [HttpGet("get-by-address", Name = "GetCarsByAddress")]
        public async Task<ActionResult<List<CarsDto>>> GetCarsByAddress([FromQuery] int id)
        {
            var carList = await _mediator.Send(new GetCarByAddressQuery() { Id = id});
            return Ok(carList);
        }

        [HttpGet("{id}", Name = "GetCarById")]
        public async Task<ActionResult<CarsDto>> GetCarById(int id)
        {
            var carById = await _mediator.Send(new GetCarByIdQuery() { Id = id});
            return Ok(carById);
        }

        [HttpPost("add", Name = "AddCar")]
        public async Task<ActionResult> AddCar([FromQuery] AddCarCommand car)
        {
            var newCar = await _mediator.Send(car);
            return Ok();
        }

        [HttpDelete("delete", Name = "DeleteCar")]
        public async Task<ActionResult> DeleteCar([FromQuery] int id)
        {
            var deletedCar = await _mediator.Send(new DeleteCarCommand() { Id = id});
            return Ok();
        }

        [HttpPut("update", Name = "UpdateCar")]
        public async Task<ActionResult> UpdateCar([FromQuery] UpdateCarCommand updateCarCommand)
        {
            var update = await _mediator.Send(updateCarCommand);

            return Ok();
        }
    }
}
