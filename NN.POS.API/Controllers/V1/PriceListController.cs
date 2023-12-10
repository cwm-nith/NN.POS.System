using MediatR;
using Microsoft.AspNetCore.Mvc;
using NN.POS.API.App.Commands.PriceLists;
using NN.POS.Model.Dtos.PriceLists;

namespace NN.POS.API.Controllers.V1;

public class PriceListController(IMediator mediator) : BaseApiController
{
    #region Price List

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreatePriceListDto body)
    {
        await mediator.Send(new CreatePriceListCommand(body));
        return Ok();
    }

    #endregion
}