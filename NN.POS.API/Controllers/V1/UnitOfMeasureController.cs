using MediatR;
using Microsoft.AspNetCore.Mvc;
using NN.POS.API.App.Commands.UnitOfMeasures;
using NN.POS.API.App.Queries.UnitOfMeasures;
using NN.POS.Common.Pagination;
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

    [HttpGet("uom-group")]
    public async Task<ActionResult<PagedResult<UnitOfMeasureGroupDto>>> GetUomGroupPage(
        [FromQuery] GetUomPageGroupQuery q)
    {
        return Ok(await mediator.Send(q));
    }

    [HttpGet("uom-group/{id}")]
    public async Task<ActionResult<UnitOfMeasureGroupDto>> GetUomGroupById(int id)
    {
        var data = await mediator.Send(new GetUomGroupByIdQuery(id));
        return Ok(data);
    }

    [HttpPut("uom-group/{id}")]
    public async Task<ActionResult<UnitOfMeasureGroupDto>> UpdateUomGroup(int id, [FromBody] UpdateUomGroupDto body)
    {
        await mediator.Send(new UpdateUomGroupCommand(id, body.Name));
        return Ok();
    }

    [HttpDelete("uom-group/{id}")]
    public async Task<ActionResult<UnitOfMeasureGroupDto>> DeleteUomGroup(int id)
    {
        await mediator.Send(new DeleteUomGroupCommand(id));
        return Ok();
    }

    #endregion

    #region UOM Define

    [HttpPost("uom-define")]
    public async Task<ActionResult> CreateUomDefine([FromBody] CreateUomDefineDto body)
    {
        await mediator.Send(new CreateUomDefineCommand(body));
        return Ok();
    }

    [HttpPut("uom-define/{id}")]
    public async Task<ActionResult> UpdateUomDefine(int id, [FromBody] CreateUomDefineDto body)
    {
        await mediator.Send(new UpdateUomDefineCommand(id, body));
        return Ok();
    }

    [HttpGet("uom-define/{id}")]
    public async Task<ActionResult> GetUomDefineById(int id)
    {
        var data = await mediator.Send(new GetUomDefineByIdQuery(id));
        return Ok(data);
    }

    [HttpGet("uom-define-uom-group-id/{id}")]
    public async Task<ActionResult> GetUomDefineByUomGroupId(int id)
    {
        var data = await mediator.Send(new GetUomDefineByUomGroupIdQuery(id));
        return Ok(data);
    }

    #endregion
}