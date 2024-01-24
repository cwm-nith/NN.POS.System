using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NN.POS.API.App.Commands.Users;
using NN.POS.Model.Dtos.Users;

namespace NN.POS.API.Controllers.V1;

public class AuthController(IMediator mediator) : BaseApiController
{
    [AllowAnonymous]
    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<UserDto>> Login([FromBody] LoginDto r)
    {
        var cmd = new LoginCommand(r.Username, r.Password);
        var user = await mediator.Send(cmd);
        return Ok(user);
    }
}