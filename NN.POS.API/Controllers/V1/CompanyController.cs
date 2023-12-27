using MediatR;
using Microsoft.AspNetCore.Mvc;
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
}