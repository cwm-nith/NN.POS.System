using Microsoft.AspNetCore.Mvc;

namespace NN.POS.System.API.Controllers.V1;

[ApiVersion("1")]
public class RoleController : BaseApiController
{
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
}