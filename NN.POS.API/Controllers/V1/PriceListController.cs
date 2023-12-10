using MediatR;
using Microsoft.AspNetCore.Mvc;
using NN.POS.API.App.Commands.PriceLists;
using NN.POS.API.App.Queries.PriceLists;
using NN.POS.Common.Pagination;
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

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, [FromBody] UpdatePriceListDto body)
    {
        await mediator.Send(new UpdatePriceListCommand
        {
            Id = id,
            Name = body.Name
        });
        return Ok();
    }

    [HttpGet]
    public async Task<ActionResult<PagedResult<PriceListDto>>> GetPage([FromQuery] GetPagePriceListDto q)
    {
        var query = new GetPagePriceListQuery
        {
            Page = q.Page,
            Results = q.Results,
            Search = q.Search
        };
        var data = await mediator.Send(query);
        return Ok(data);
    }

    #endregion
}