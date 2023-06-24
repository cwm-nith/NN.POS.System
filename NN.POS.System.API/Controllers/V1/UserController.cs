using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NN.POS.System.API.App.Commands.Users;
using NN.POS.System.API.App.Queries.Users;
using NN.POS.System.API.Commons.Pagination;
using NN.POS.System.API.Core.Dtos.Users;

namespace NN.POS.System.API.Controllers.V1;

[ApiVersion("1")]
public class UserController : BaseApiController
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Get all users
    /// </summary>
    /// <returns></returns>

    [Authorize(Roles = "Admin,read-user")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<PagedResult<UserDto>>> Get([FromQuery] PagedQuery q)
    {
        var query = new GetUserQuery()
        {
            Page = q.Page,
            Results = q.Results,
        };
        var data = await _mediator.Send(query);
        return Ok(data);
    }

    [Authorize(Roles = "Admin,read-user")]
    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<UserDto>> GetUserById(int id)
    {
        var query = new GetUserByIdQuery(id);
        var data = await _mediator.Send(query);
        return Ok(data);
    }

    [Authorize(Roles = "Admin,read-user")]
    [HttpGet("{username}/username")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<UserDto>> GetUserByName(string username)
    {
        var query = new GetUserByNameQuery(username);
        var data = await _mediator.Send(query);
        return Ok(data);
    }


    [Authorize(Roles = "Admin,write-user")]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<UserDto>> CreateUser([FromBody] CreateUserDto body)
    {
        var cmd = new CreateUserCommand(name: body.Name, username: body.Username, password: body.Password,
            email: body.Email, updatedAt: DateTime.UtcNow);
        var data = await _mediator.Send(cmd);
        return Ok(data);
    }
}