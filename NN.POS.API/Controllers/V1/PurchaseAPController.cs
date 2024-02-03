using MediatR;
using Microsoft.AspNetCore.Mvc;
using NN.POS.API.App.Commands.Purchases.PurchaseAP;
using NN.POS.API.App.Queries.Purchases;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.Purchases.PurchaseAP;
using NN.POS.Model.Dtos.Purchases.PurchasePO;

namespace NN.POS.API.Controllers.V1;

public class PurchaseAPController(IMediator mediator) : BaseApiController
{
    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreatePurchaseAPDto body)
    {
        await mediator.Send(new CreatePurchaseAPCommand(UserId, body));
        return Ok();
    }

    [HttpGet]
    public async Task<ActionResult<PagedResult<PurchaseAPDto>>> GetPage([FromQuery] GetPurchaseAPPageQuery query)
    {
        return Ok(await mediator.Send(query));
    }
}
