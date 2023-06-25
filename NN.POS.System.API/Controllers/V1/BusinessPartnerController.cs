using Microsoft.AspNetCore.Mvc;

namespace NN.POS.System.API.Controllers.V1;

public class BusinessPartnerController : BaseApiController
{

    [HttpGet]
    public ActionResult Get()
    {
        return Ok("Hello");
    }
}