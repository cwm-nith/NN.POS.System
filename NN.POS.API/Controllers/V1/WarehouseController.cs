using MediatR;
using Microsoft.AspNetCore.Mvc;
using NN.POS.API.App.Queries.Warehouses;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.Warehouses;

namespace NN.POS.API.Controllers.V1;

public class WarehouseController(IMediator mediator) : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<PagedResult<WarehouseDto>>> GetPage([FromQuery] GetPageWarehouseDto q)
    {
        var data = await mediator.Send(new GetPageWarehouseQuery
        {
            Page = q.Page,
            Results = q.Results,
            Search = q.Search
        });
        return Ok(data);
    }
}