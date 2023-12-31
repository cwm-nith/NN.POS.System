using MediatR;
using Microsoft.AspNetCore.Mvc;
using NN.POS.API.App.Commands.Currencies;
using NN.POS.API.App.Queries.Currencies;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.Currencies;

namespace NN.POS.API.Controllers.V1;

public class ExchangeRateController(IMediator mediator) : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<PagedResult<ExchangeRateDto>>> GetPage([FromQuery] GetExchangeRatePageQuery query)
    {
        var data = await mediator.Send(query);
        return Ok(data);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ExchangeRateDto>> GetById(int id)
    {
        var data = await mediator.Send(new GetExchangeRateByIdQuery(id));
        return Ok(data);
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreateExchangeRateDto exchangeRateDto)
    {
        await mediator.Send(new CreateExchangeRateCommand(exchangeRateDto));
        return Ok();
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Update(int id, [FromBody] CreateExchangeRateDto exchangeRateDto)
    {
        await mediator.Send(new UpdateExchangeRateCommand(id, exchangeRateDto));
        return Ok();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        await mediator.Send(new DeleteExchangeRateCommand(id));
        return Ok();
    }
}