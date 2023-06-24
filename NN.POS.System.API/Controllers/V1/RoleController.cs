using Microsoft.AspNetCore.Mvc;

namespace NN.POS.System.API.Controllers.V1;

[ApiVersion("1")]
public class RoleController : BaseApiController
{
    [HttpGet]
    public ActionResult Get()
    {
        return Ok(new {Id = 10});
    }
}