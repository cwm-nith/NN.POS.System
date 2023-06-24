using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NN.POS.System.API.App.Commands.Roles;
using NN.POS.System.API.Core.Dtos.Roles;

namespace NN.POS.System.API.Controllers.V1;

[ApiVersion("1")]
public class RoleController : BaseApiController
{
    private readonly IMediator _mediator;

    public RoleController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public ActionResult Get()
    {
        return Ok(new {Id = 10});
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
}