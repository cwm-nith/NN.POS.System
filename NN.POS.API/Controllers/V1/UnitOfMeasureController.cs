using MediatR;
using Microsoft.AspNetCore.Mvc;
using NN.POS.API.App.Commands.UnitOfMeasures;
using NN.POS.API.App.Queries.UnitOfMeasures;
using NN.POS.Model.Dtos.UnitOfMeasures;

namespace NN.POS.API.Controllers.V1;

public class UnitOfMeasureController(IMediator mediator) : BaseApiController
{
    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreateUomDto body)
    {
        var cmd = new CreateUomCommand
        {
            Name = body.Name
        };
        await mediator.Send(cmd);
        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UnitOfMeasureDto>> GetById(int id)
    {
        var data = await mediator.Send(new GetUomByIdQuery(id));
        return Ok(data);
    }

    [HttpGet]
    public async Task<ActionResult<UnitOfMeasureDto>> Get([FromQuery] GetPageUomDto q)
    {
        var data = await mediator.Send(new GetUomPageQuery
        {
            Page = q.Page,
            Results = q.Results,
            Search = q.Search
        });
        return Ok(data);
    }
}