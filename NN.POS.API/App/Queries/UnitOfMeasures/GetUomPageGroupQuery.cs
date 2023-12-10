using MediatR;using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.UnitOfMeasures;

namespace NN.POS.API.App.Queries.UnitOfMeasures;

public class GetUomPageGroupQuery : PagedQuery, IRequest<PagedResult<UnitOfMeasureGroupDto>>
{
    public string? Search { get; set; }
}