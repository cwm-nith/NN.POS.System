using MediatR;
using Microsoft.AspNetCore.Mvc;
using NN.POS.API.App.Commands.UnitOfMeasures;
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
}