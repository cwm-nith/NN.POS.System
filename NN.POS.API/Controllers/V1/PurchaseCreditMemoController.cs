using MediatR;
using Microsoft.AspNetCore.Mvc;
using NN.POS.API.App.Commands.Purchases.PurchaseCreditMemo;
using NN.POS.API.App.Queries.Purchases;
using NN.POS.Common.Pagination;
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

    [HttpGet]
    public async Task<ActionResult<PagedResult<PurchaseCreditMemoDto>>> GetPage([FromQuery] GetPurchaseCreditMemoPageQuery q)
    {
        return Ok(await mediator.Send(q));
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<PurchaseCreditMemoDto>> GetById(int id)
    {
        return Ok(await mediator.Send(new GetPurchaseCreditMemoByIdOrInvoiceQuery(id, true)));
    }
}
