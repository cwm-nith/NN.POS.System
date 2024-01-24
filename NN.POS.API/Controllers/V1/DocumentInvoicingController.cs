using MediatR;
using Microsoft.AspNetCore.Mvc;
using NN.POS.API.App.Queries.DocumentInvoicing;
using NN.POS.Model.Dtos.DocumentInvoicings;

namespace NN.POS.API.Controllers.V1;

public class DocumentInvoicingController(IMediator mediator) : BaseApiController
{
    [HttpGet("get_next_invoice")]
    public async Task<ActionResult<DocumentInvoicingDto>> GetNextInvoice([FromQuery] GetNextInvoiceQuery q)
    {
        return Ok(await mediator.Send(q));
    }
}