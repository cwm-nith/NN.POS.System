using MediatR;
using NN.POS.API.App.Queries.Currencies;
using NN.POS.API.Core.IRepositories.Currencies;
using NN.POS.Model.Dtos.Currencies;

namespace NN.POS.API.Infra.QueryHandlers.Currencies;

public class GetLocalCurrencyQueryHandler(ICurrencyRepository repository) : IRequestHandler<GetLocalCurrencyQuery, CurrencyDto>
{
    public async Task<CurrencyDto> Handle(GetLocalCurrencyQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetLocalCurrencyAsync(cancellationToken);
    }
}