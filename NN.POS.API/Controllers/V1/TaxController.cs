using MediatR;
using Microsoft.AspNetCore.Mvc;
using NN.POS.API.App.Commands.Tax;
using NN.POS.API.App.Queries.Tax;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.Tax;

namespace NN.POS.API.Controllers.V1;

public class TaxController(IMediator mediator) : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<PagedResult<TaxDto>>> GetPage([FromQuery] GetTaxPageQuery query)
    {
        var data = await mediator.Send(query);
        return Ok(data);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<TaxDto>> GetById(int id)
    {
        var data = await mediator.Send(new GetTaxByIdQuery(id));
        return Ok(data);
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreateTaxDto body)
    {
        await mediator.Send(new CreateTaxCommand(body));
        return Ok();
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Update(int id, [FromBody] CreateTaxDto body)
    {
        await mediator.Send(new UpdateTaxCommand(id, body));
        return Ok();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        await mediator.Send(new DeleteTaxCommand(id));
        return Ok();
    }

}