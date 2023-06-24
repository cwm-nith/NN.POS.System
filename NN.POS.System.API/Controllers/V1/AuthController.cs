using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NN.POS.System.API.App.Commands.Users;
using NN.POS.System.API.Core.Dtos.Users;

namespace NN.POS.System.API.Controllers.V1;

public class AuthController : BaseApiController
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<ActionResult<UserDto>> Login([FromBody] LoginDto r)
    {
        var cmd = new LoginCommand(r.Username, r.Password);
        var user = await _mediator.Send(cmd);
        return Ok(user);
    }
}