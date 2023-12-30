using MediatR;
using Microsoft.AspNetCore.Mvc;
using NN.POS.API.App.Queries.Tax;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.Tax;

namespace NN.POS.API.Controllers.V1;

public class TaxController(IMediator mediator) : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<PagedResult<TaxDto>>> GetPage([FromQuery] GetTaxPageQuery query)
    {
        var data = await mediator.Send(query);
        return Ok(data);
    }
}