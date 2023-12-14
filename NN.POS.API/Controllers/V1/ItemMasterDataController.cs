using MediatR;
using Microsoft.AspNetCore.Mvc;
using NN.POS.API.App.Commands.ItemMasterData;
using NN.POS.Model.Dtos.ItemMasters;

namespace NN.POS.API.Controllers.V1;

public class ItemMasterDataController(IMediator mediator) : BaseApiController
{

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreateItemMasterDataDto body)
    {
        var cmd = new CreateItemMasterDataCommand(body);
        await mediator.Send(cmd);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, [FromBody] UpdateItemMasterDataDto body)
    {
        var cmd = new UpdateItemMasterDataCommand(id, body);
        await mediator.Send(cmd);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var cmd = new DeleteItemMasterDataCommand(id);
        await mediator.Send(cmd);
        return Ok();
    }

    
}