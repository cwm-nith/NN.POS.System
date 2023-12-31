using MediatR;
using Microsoft.AspNetCore.Mvc;
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
}