using MediatR;
using Microsoft.AspNetCore.Mvc;
using NN.POS.API.App.Queries.Purchases;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.Purchases.PurchaseOrders;
using NN.POS.Model.Dtos.Purchases.PurchasePO;

namespace NN.POS.API.Controllers.V1;

public class PurchasePOController(IMediator mediator) : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<PagedResult<PurchasePODto>>> GetPage([FromQuery] GetPurchasePOPageQuery query)
    {
        return Ok(await mediator.Send(query));
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<PurchaseOrderDto>> GetById(int id)
    {
        return Ok(await mediator.Send(new GetPurchaseOrderByIdOrInvoiceQuery(id, true)));
    }
}
