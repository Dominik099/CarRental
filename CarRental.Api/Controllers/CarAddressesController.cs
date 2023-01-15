using CarRental.Application.Functions.CarAddresses.Queries.GetCarAddressList;
using CarRental.Application.Functions.CarAddresses.Queries.GetCarAddressById;
using CarRental.Application.Functions.Cars.Queries.GetCarsList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarRental.Application.Functions.CarAddresses.Commands.AddCarAddress;
using CarRental.Application.Functions.CarAddresses.Commands.DeleteCarAddress;
using CarRental.Application.Functions.CarAddresses.Commands.UpdateCarAddress;
using CarRental.Domain.Entities;
using CarRental.Application.Functions.CarAddresses.Queries.GetCarAddressByCar;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using NuGet.Protocol;

namespace CarRental.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarAddressesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarAddressesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllAddresses")]
        public async Task<ActionResult<List<CarAddressDto>>> GetAllAddresses()
        {
            var carList = await _mediator.Send(new GetCarAddressesListQuery());
            return Ok(carList);
        }

        [HttpGet("get-by-car", Name = "GetCarAddresses")]
        public async Task<ActionResult<List<CarAddress>>> GetCarAddresses([FromQuery] int carId)
        {
            var carList = await _mediator.Send(new GetCarAddressByCarQuery() { CarId = carId});
            return Ok(carList);
        }

        [HttpGet("{id}", Name = "GetCarAddressById")]
        public async Task<ActionResult<CarAddressDto>> GetCarAddressById(int id)
        {
            var carAddress = await _mediator.Send(new GetCarAddressByIdQuery() { Id = id});
            return Ok(carAddress);
        }

        [HttpPost("add", Name = "AddCarAddress")]
        public async Task<ActionResult<AddCarAddressCommandResponse>> AddCarAddress([FromQuery] AddCarAddressCommand addCarAddressCommand)
        {
            //addCarAddressCommand.UserId = int.Parse(User.FindFirst(x => x.Type == ClaimTypes.NameIdentifier).Value);
            var newCarAddress = await _mediator.Send(addCarAddressCommand);

            return Ok(newCarAddress);
        }

        [HttpDelete("delete", Name = "DeleteCarAddress")]
        [Authorize]
        public async Task<ActionResult> DeleteCarAddress([FromQuery] int id)
        {           

            var deletedCarAddress = await _mediator.Send(new DeleteCarAddressCommand() { Id = id, /*User = User*/});

            return NoContent();
        }

        [HttpPut("update", Name = "UpdateCarAddress")]
        public async Task<ActionResult> UpdateCarAddress([FromQuery] UpdateCarAddressCommand updateCarAddressCommand)
        {
            //updateCarAddressCommand.User = User;

            var updatedCarAddress = await _mediator.Send(updateCarAddressCommand);

            return NoContent();
        }
    }
}
