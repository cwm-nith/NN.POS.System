using MediatR;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.Company;

namespace NN.POS.API.App.Queries.Company;

public class GetCompanyPageQuery : PagedQuery, IRequest<PagedResult<CompanyDto>>
{
    public string? Search { get; set; }
}