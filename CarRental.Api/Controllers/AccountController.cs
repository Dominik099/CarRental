using CarRental.Application.Functions.UsersAccounts.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Api.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;   
        }

        [HttpPost("register", Name = "AddUser")]
        public async Task<ActionResult<AddUserAccountCommandResponse>> RegisterUser([FromQuery] AddUserAccountCommand addUserAccountCommand)
        {
            var user = await _mediator.Send(addUserAccountCommand);

            return Ok(user);
        }
    }
}
