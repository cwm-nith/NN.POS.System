﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using NN.POS.API.App.Queries.Company;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.Company.Branches;

namespace NN.POS.API.Controllers.V1;

public class BranchController(IMediator mediator) : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<PagedResult<BranchDto>>> GetPage([FromQuery] GetBranchPageQuery query)
    {
        var data = await mediator.Send(query);
        return Ok(data);
    }
}