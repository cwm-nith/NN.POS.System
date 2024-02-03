using MediatR;
using Microsoft.AspNetCore.Mvc;
using NN.POS.API.App.Commands.Purchases.PurchaseAP;
using NN.POS.Model.Dtos.Purchases.PurchaseAP;

namespace NN.POS.API.Controllers.V1;

public class PurchaseAPController(IMediator mediator) : BaseApiController
{
    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreatePurchaseAPDto body)
    {
        await mediator.Send(new CreatePurchaseAPCommand(UserId, body));
        return Ok();
    }
}
