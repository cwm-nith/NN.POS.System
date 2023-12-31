using MediatR;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.Currencies;

namespace NN.POS.API.App.Queries.Currencies;

public class GetExchangeRatePageQuery : PagedQuery, IRequest<PagedResult<ExchangeRateDto>>
{
    public string? Search { get; set; }
}