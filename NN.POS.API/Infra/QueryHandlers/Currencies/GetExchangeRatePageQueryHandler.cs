using MediatR;
using NN.POS.API.App.Queries.Currencies;
using NN.POS.API.Core.IRepositories.Currencies;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.Currencies;

namespace NN.POS.API.Infra.QueryHandlers.Currencies;

public class GetExchangeRatePageQueryHandler(IExchangeRateRepository repository) : IRequestHandler<GetExchangeRatePageQuery, PagedResult<ExchangeRateDto>>
{
    public async Task<PagedResult<ExchangeRateDto>> Handle(GetExchangeRatePageQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetPageAsync(request, cancellationToken);
    }
}