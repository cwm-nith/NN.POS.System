using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NN.POS.API.App.Commands.UserRoles;
using NN.POS.API.App.Queries.UserRoles;
using NN.POS.Model.Dtos.Roles;

namespace NN.POS.API.Controllers.V1;

public class UserRoleController : BaseApiController
{
    private readonly IMediator _mediator;

    public UserRoleController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Authorize(Roles = "Admin, read-role")]
    [HttpGet("{userId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<List<UserRoleDto>>> GetUserRoles(int userId)
    {
        var q = new GetUserRoleByUserIdQuery(userId);
        var data = await _mediator.Send(q);
        return Ok(data);
    }

    [Authorize(Roles = "Admin, read-role")]
    [HttpGet("{userId:int}/all")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<List<UserRoleDto>>> GetAllUserRoles(int userId)
    {
        var q = new GetAllUserRoleByUserIdQuery(userId);
        var data = await _mediator.Send(q);
        return Ok(data);
    }

    [Authorize(Roles = "Admin, write-role")]
    [HttpPost("{userId:int}/{roleId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<bool>> AddRoleToUser(int userId, int roleId)
    {
        var q = new AddRoleToUserCommand(userId, roleId);
        var data = await _mediator.Send(q);
        return Ok(data);
    }

    [Authorize(Roles = "Admin, write-role")]
    [HttpDelete("{userId:int}/{roleId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<bool>> RemoveUserRole(int userId, int roleId)
    {
        var q = new RemoveUserRoleCommand(userId, roleId);
        var data = await _mediator.Send(q);
        return Ok(data);
    }
}