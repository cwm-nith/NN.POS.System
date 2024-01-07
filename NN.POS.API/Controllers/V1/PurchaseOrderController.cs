using MediatR;
using Microsoft.AspNetCore.Mvc;
using NN.POS.API.App.Commands.Purchases.PurchaseOrders;
using NN.POS.API.App.Queries.Purchases;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.Purchases.PurchaseOrders;

namespace NN.POS.API.Controllers.V1;

public class PurchaseOrderController(IMediator mediator) : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<PagedResult<PurchaseOrderDto>>> GetPage([FromQuery] GetPurchaseOrderPageQuery query)
    {
        return Ok(await mediator.Send(query));
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<PurchaseOrderDto>> GetById(int id)
    {
        return Ok(await mediator.Send(new GetPurchaseOrderByIdOrInvoiceQuery(id, true)));
    }

    [HttpGet("invoice/{invoice}")]
    public async Task<ActionResult<PurchaseOrderDto>> GetByInvoice(string invoice)
    {
        return Ok(await mediator.Send(new GetPurchaseOrderByIdOrInvoiceQuery(invoice, false)));
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreatePurchaseOrderDto body)
    {
        await mediator.Send(new CreatePurchaseOrderCommand(UserId, body));
        return Ok();
    }
}