using MediatR;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.Currencies;

namespace NN.POS.API.App.Queries.Currencies;

public class GetCurrenciesPageQuery : PagedQuery, IRequest<PagedResult<CurrencyDto>>
{
    public string? Search { get; set; }
}