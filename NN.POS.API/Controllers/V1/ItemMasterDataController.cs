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
}