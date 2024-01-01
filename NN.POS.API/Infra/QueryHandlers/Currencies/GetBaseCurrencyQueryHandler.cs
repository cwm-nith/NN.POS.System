using MediatR;
using NN.POS.API.App.Queries.Currencies;
using NN.POS.API.Core.IRepositories.Currencies;
using NN.POS.Model.Dtos.Currencies;

namespace NN.POS.API.Infra.QueryHandlers.Currencies;

public class GetBaseCurrencyQueryHandler(ICurrencyRepository repository) : IRequestHandler<GetBaseCurrencyQuery, CurrencyDto>
{
    public async Task<CurrencyDto> Handle(GetBaseCurrencyQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetBaseCurrencyAsync(cancellationToken);
    }
}