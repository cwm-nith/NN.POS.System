using MediatR;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.PriceLists;

namespace NN.POS.API.App.Queries.PriceLists;

public class GetPagePriceListDetailQuery : PagedQuery, IRequest<PagedResult<PriceListDetailDto>>
{
    public int PriceListId { get; set; }
    public string? Search { get; set; }
}