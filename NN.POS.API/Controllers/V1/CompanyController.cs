using MediatR;
using Microsoft.AspNetCore.Mvc;
using NN.POS.API.App.Commands.Company;
using NN.POS.API.App.Queries.Company;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.Company;

namespace NN.POS.API.Controllers.V1;

public class CompanyController(IMediator mediator) : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<PagedResult<CompanyDto>>> GetPage([FromQuery] GetCompanyPageDto q)
    {
        var data = await mediator.Send(new GetCompanyPageQuery
        {
            Page = q.Page,
            Results = q.Results,
            Search = q.Search
        });
        return Ok(data);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<CompanyDto>> GetById(int id)
    {
        var data = await mediator.Send(new GetCompanyByIdQuery(id));
        return Ok(data);
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromForm] CreateCompanyDto body)
    {
        await mediator.Send(new CreateCompanyCommand(body));
        return Ok();
    }

}