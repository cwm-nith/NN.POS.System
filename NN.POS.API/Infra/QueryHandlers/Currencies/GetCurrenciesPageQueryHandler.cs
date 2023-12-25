using MediatR;
using NN.POS.API.App.Queries.Currencies;
using NN.POS.API.Core.IRepositories.Currencies;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.Currencies;

namespace NN.POS.API.Infra.QueryHandlers.Currencies;

public class GetCurrenciesPageQueryHandler(ICurrencyRepository repository) : IRequestHandler<GetCurrenciesPageQuery, PagedResult<CurrencyDto>>
{
    public async Task<PagedResult<CurrencyDto>> Handle(GetCurrenciesPageQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetPageAsync(request, cancellationToken);
    }
}