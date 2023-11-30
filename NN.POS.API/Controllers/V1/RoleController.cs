using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NN.POS.API.App.Commands.Roles;
using NN.POS.API.App.Queries.Roles;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.Roles;

namespace NN.POS.API.Controllers.V1;

[ApiVersion("1")]
public class RoleController : BaseApiController
{
    private readonly IMediator _mediator;

    public RoleController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Authorize(Roles = "Admin, read-role")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<PagedResult<RoleDto>>> Get([FromQuery] PagedQuery r)
    {
        var q = new GetRoleQuery()
        {
            Results = r.Results,
            Page = r.Page,
        };
        return Ok(await _mediator.Send(q));
    }

    [Authorize(Roles = "Admin,write-role")]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<RoleDto>> CreateRole([FromBody] CreateRoleDto b)
    {
        var cmd = new CreateRoleCommand(b.Name)
        {
            Description = b.Description,
            DisplayName = b.DisplayName,
        };

        var data = await _mediator.Send(cmd);
        return Ok(data);
    }

    [Authorize(Roles = "Admin,write-role")]
    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<RoleDto>> UpdateRole(int id, [FromBody] UpdateRoleDto b)
    {
        var cmd = new UpdateRoleCommand(id, b.Name)
        {
            Description = b.Description,
            DisplayName = b.DisplayName,
        };

        var data = await _mediator.Send(cmd);
        return Ok(data);
    }


    [Authorize(Roles = "Admin,write-role")]
    [HttpGet("{id:int}")]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<RoleDto>> GetRole(int id)
    {
        var cmd = new GetRoleByIdQuery
        {
            Id = id
        };

        var data = await _mediator.Send(cmd);
        return Ok(data);
    }

    [Authorize(Roles = "Admin,write-role")]
    [HttpPost("create-many")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<RoleDto>> CreateMany([FromBody] List<CreateRoleDto> b)
    {
        var cmd = new CreateRoleManyCommand(b);

        var data = await _mediator.Send(cmd);
        return Ok(data);
    }

    [Authorize(Roles = "Admin,write-role")]
    [HttpPut("update-many")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<bool>> UpdateMany([FromBody] List<UpdateRoleDto> b)
    {
        var cmd = new UpdateRoleManyCommand(b);

        var data = await _mediator.Send(cmd);
        return Ok(data);
    }

    [Authorize(Roles = "Admin,write-role")]
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<bool>> DeleteById(int id)
    {
        var cmd = new DeleteRoleByIdCommand(id);

        var data = await _mediator.Send(cmd);
        return Ok(data);
    }

    [Authorize(Roles = "Admin,write-role")]
    [HttpDelete("{name}/by-name")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<bool>> DeleteByName(string name)
    {
        var cmd = new DeleteRoleByNameCommand(name);

        var data = await _mediator.Send(cmd);
        return Ok(data);
    }

}