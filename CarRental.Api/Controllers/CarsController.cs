using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarRental.Application.Functions.Cars.Queries.GetCarsList;
using CarRental.Application.Functions.CarAddresses.Queries.GetCarAddressList;

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
            var carList = await _mediator.Send(new GetCarsListQuery());
            return Ok(carList);
        }
    }
}
