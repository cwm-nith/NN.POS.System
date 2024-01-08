using MediatR;
using Microsoft.AspNetCore.Mvc;
using NN.POS.API.App.Commands.ItemMasterData;
using NN.POS.API.App.Queries.ItemMasters;
using NN.POS.Model.Dtos.ItemMasters;

namespace NN.POS.API.Controllers.V1;

public class ItemMasterDataController(IMediator mediator) : BaseApiController
{

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreateItemMasterDataDto body)
    {
        var cmd = new CreateItemMasterDataCommand(UserId, body);
        await mediator.Send(cmd);
        return Ok();
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Update(int id, [FromBody] UpdateItemMasterDataDto body)
    {
        var cmd = new UpdateItemMasterDataCommand(id, body);
        await mediator.Send(cmd);
        return Ok();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        var cmd = new DeleteItemMasterDataCommand(id);
        await mediator.Send(cmd);
        return Ok();
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetById(int id)
    {
        var q = new GetItemMasterDataByIdQuery(id);
        var data  =await mediator.Send(q);
        return Ok(data);
    }

    [HttpGet("get-unique")]
    public async Task<ActionResult> GetUnique([FromQuery] GeyItemMasterDataUniqueDto q)
    {
        var query = new GetItemMasterDataUniqueQuery(q);
        var data = await mediator.Send(query);
        return Ok(data);
    }

    [HttpGet]
    public async Task<ActionResult> GetPage([FromQuery] GetPageItemMasterDataDto q)
    {
        var query = new GetPageItemMasterDataQuery
        {
            Page = q.Page,
            Process = q.Process,
            Results = q.Results,
            Search = q.Search,
            Type = q.Type
        };
        var data = await mediator.Send(query);
        return Ok(data);
    }

    [HttpPost("update-img")]
    public async Task<ActionResult> UpdateImage([FromForm] UpdateItemMasterImageDto body)
    {
        var cmd = new UpdateItemMasterImageCommand(body);
        await mediator.Send(cmd);
        return Ok();
    }
}