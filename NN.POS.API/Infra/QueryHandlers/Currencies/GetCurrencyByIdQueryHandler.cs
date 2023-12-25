using MediatR;
using NN.POS.API.App.Queries.Currencies;
using NN.POS.API.Core.IRepositories.Currencies;
using NN.POS.Model.Dtos.Currencies;

namespace NN.POS.API.Infra.QueryHandlers.Currencies;

public class GetCurrencyByIdQueryHandler(ICurrencyRepository repository) : IRequestHandler<GetCurrencyByIdQuery, CurrencyDto>
{
    public async Task<CurrencyDto> Handle(GetCurrencyByIdQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetByIdAsync(request.Id, cancellationToken);
    }
}
