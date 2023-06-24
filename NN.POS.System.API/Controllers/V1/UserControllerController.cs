using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NN.POS.System.API.App.Commands.Users;
using NN.POS.System.API.Core.Dtos.Users;

namespace NN.POS.System.API.Controllers.V1;

[ApiVersion("1")]
public class UserControllerController : BaseApiController
{
    private readonly IMediator _mediator;

    public UserControllerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Get test data example with no auth
    /// </summary>
    /// <returns></returns>

    [Authorize(Roles = "Admin,read-user")]
    [HttpGet]
    public ActionResult Get()
    {
        return Ok(new
        {
            Name = "Hello",
            Id = 2
        });
    }
    [Authorize(Roles = "Admin,write-user")]
    [HttpPost]
    public async Task<ActionResult<UserDto>> CreateUser([FromBody] CreateUserDto body)
    {
        var cmd = new CreateUserCommand(name: body.Name, username: body.Username, password: body.Password,
            email: body.Email, updatedAt: DateTime.UtcNow);
        var data = await _mediator.Send(cmd);
        return Ok(data);
    }
}