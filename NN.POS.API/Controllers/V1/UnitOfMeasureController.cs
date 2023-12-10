using MediatR;
using Microsoft.AspNetCore.Mvc;
using NN.POS.API.App.Commands.UnitOfMeasures;
using NN.POS.API.App.Queries.UnitOfMeasures;
using NN.POS.Model.Dtos.UnitOfMeasures;

namespace NN.POS.API.Controllers.V1;

public class UnitOfMeasureController(IMediator mediator) : BaseApiController
{
    #region UOM

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

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, [FromBody] UpdateUomDto body)
    {
        await mediator.Send(new UpdateUomCommand
        {
            Id = id,
            Name = body.Name
        });
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await mediator.Send(new DeleteUomCommand
        {
            Id = id
        });
        return Ok();
    }

    #endregion

    #region UOM Group

    [HttpPost("uom-group")]
    public async Task<ActionResult> CreateUomGroup([FromBody] CreateUomGroupDto body)
    {
        var cmd = new CreateUomGroupCommand(body.Name);
        await mediator.Send(cmd);
        return Ok();
    }

    [HttpPost("uom-group/{id}")]
    public async Task<ActionResult<UnitOfMeasureGroupDto>> GetUomGroupById(int id)
    {
        var data = await mediator.Send(new GetUomGroupByIdQuery(id));
        return Ok(data);
    }

    #endregion
}