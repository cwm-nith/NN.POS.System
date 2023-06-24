using Microsoft.AspNetCore.Mvc;

namespace NN.POS.System.API.Controllers.V2;

[ApiVersion("2")]
public class TestV2Controller : BaseApiController
{
    [HttpGet]
    public ActionResult Get()
    {
        return Ok(new { Id = 3, Name = "nith v2" });
    }
}