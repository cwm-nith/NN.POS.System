using MediatR;
using Microsoft.AspNetCore.Mvc;
using NN.POS.API.App.Commands.Purchases.PurchaseCreditMemo;
using NN.POS.Model.Dtos.Purchases.PurchaseCreditMemo;

namespace NN.POS.API.Controllers.V1;

public class PurchaseCreditMemoController(IMediator mediator) : BaseApiController
{
    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreatePurchaseCreditMemoDto req)
    {
        var data = await mediator.Send(new CreatePurchaseCreditMemoCommand(UserId, req)); 
        if(data == null)
        {
            return Ok();
        }
        return BadRequest(data);
    }
}
