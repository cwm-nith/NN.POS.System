using MediatR;
using Microsoft.AspNetCore.Mvc;
using NN.POS.API.App.Commands.Currencies;
using NN.POS.Model.Dtos.Currencies;

namespace NN.POS.API.Controllers.V1;

public class CurrencyController(IMediator mediator) : BaseApiController
{
    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreateCurrencyDto body)
    {
        await mediator.Send(new CreateCurrencyCommand(body));
        return Ok();
    }
}