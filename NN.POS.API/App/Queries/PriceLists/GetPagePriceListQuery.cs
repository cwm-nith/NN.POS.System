using MediatR;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.PriceLists;

namespace NN.POS.API.App.Queries.PriceLists;

public class GetPagePriceListQuery : PagedQuery, IRequest<PagedResult<PriceListDto>>
{
    public string? Search { get; set; }
    public int? ExcludeId { get; set; }
}