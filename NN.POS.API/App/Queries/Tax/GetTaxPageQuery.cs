using MediatR;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.Tax;

namespace NN.POS.API.App.Queries.Tax;

public class GetTaxPageQuery : PagedQuery, IRequest<PagedResult<TaxDto>>
{
    public string? Search { get; set; }
}