using MediatR;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.Company.Branches;

namespace NN.POS.API.App.Queries.Company;

public class GetBranchPageQuery : PagedQuery, IRequest<PagedResult<BranchDto>>
{
    public string? Search { get; set; }
}