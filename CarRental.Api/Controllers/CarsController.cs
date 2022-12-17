using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarRental.Application.Functions.Cars.Queries.GetCarsList;
using CarRental.Application.Functions.CarAddresses.Queries.GetCarAddressList;
using CarRental.Application.Functions.Cars.Queries.GetCarById;

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
        public async Task<ActionResult<List<CarViewModel>>> GetAllCars()
        {
            var carList = await _mediator.Send(new GetAllCarsListQuery());
            return Ok(carList);
        }

        [HttpGet("{id}", Name = "GetCarById")]
        public async Task<ActionResult<CarViewModel>> GetCarById(int id)
        {
            var carById = await _mediator.Send(new GetCarByIdQuery() { Id = id});
            return Ok(carById);
        }
    }
}
