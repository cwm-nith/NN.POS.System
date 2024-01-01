using MediatR;
using Microsoft.AspNetCore.Mvc;
using NN.POS.API.App.Commands.PaymentTypes;
using NN.POS.API.App.Queries.PaymentTypes;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.PaymentTypes;

namespace NN.POS.API.Controllers;

public class PaymentTypeController(IMediator mediator) : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<PagedResult<PaymentTypeDto>>> GetPage([FromQuery] GetPaymentTypePageQuery query)
    {
        return Ok(await mediator.Send(query));
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<PaymentTypeDto>> GetById(int id)
    {
        return Ok(await mediator.Send(new GetPaymentTypeByIdQuery(id)));
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreatePaymentTypeDto body)
    {
        await mediator.Send(new CreatePaymentTypeCommand(body));
        return Ok();
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Update(int id, [FromBody] CreatePaymentTypeDto body)
    {
        await mediator.Send(new UpdatePaymentTypeCommand(id, body));
        return Ok();
    }
}