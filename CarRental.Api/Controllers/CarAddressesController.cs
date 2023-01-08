﻿using CarRental.Application.Functions.CarAddresses.Queries.GetCarAddressList;
using CarRental.Application.Functions.CarAddresses.Queries.GetCarAddressById;
using CarRental.Application.Functions.Cars.Queries.GetCarsList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarRental.Application.Functions.CarAddresses.Commands.AddCarAddress;

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

        [HttpGet("{id}", Name = "GetCarAddressById")]
        public async Task<ActionResult<CarAddressDto>> GetCarAddressById(int id)
        {
            var carAddress = await _mediator.Send(new GetCarAddressByIdQuery() { Id = id});
            return Ok(carAddress);
        }

        [HttpPost("add", Name = "AddCarAddress")]
        public async Task<ActionResult<AddCarAddressCommandResponse>> AddCarAddress([FromQuery] AddCarAddressCommand addCarAddressCommand)
        {
            var newCarAddress = await _mediator.Send(addCarAddressCommand);

            return Ok(newCarAddress);
        }
    }
}
