using MediatR;
using Microsoft.AspNetCore.Mvc;
using NN.POS.API.App.Commands.Currencies;
using NN.POS.API.App.Queries.Currencies;
using NN.POS.Common.Pagination;
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

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Update(int id, [FromBody] CreateCurrencyDto body)
    {
        await mediator.Send(new UpdateCurrencyCommand(id, body));
        return Ok();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        await mediator.Send(new DeleteCurrencyCommand(id));
        return Ok();
    }

    [HttpGet]
    public async Task<ActionResult<PagedResult<CurrencyDto>>> GetPage([FromQuery] GetCurrenciesPageDto q)
    {
        var data = await mediator.Send(new GetCurrenciesPageQuery
        {
            Page = q.Page,
            Results = q.Results,
            Search = q.Search
        });
        return Ok(data);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<CurrencyDto>> GetById(int id)
    {
        var data = await mediator.Send(new GetCurrencyByIdQuery(id));
        return Ok(data);
    }

    [HttpGet("base-currency")]
    public async Task<ActionResult<CurrencyDto>> GetBaseCurrency()
    {
        var data = await mediator.Send(new GetBaseCurrencyQuery());
        return Ok(data);
    }

    [HttpGet("local-currency")]
    public async Task<ActionResult<CurrencyDto>> GetLocalCurrency()
    {
        var data = await mediator.Send(new GetLocalCurrencyQuery());
        return Ok(data);
    }
}