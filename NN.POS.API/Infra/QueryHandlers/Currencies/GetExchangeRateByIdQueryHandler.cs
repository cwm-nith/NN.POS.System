using MediatR;
using NN.POS.API.App.Queries.Currencies;
using NN.POS.API.Core.IRepositories.Currencies;
using NN.POS.Model.Dtos.Currencies;

namespace NN.POS.API.Infra.QueryHandlers.Currencies;

public class GetExchangeRateByIdQueryHandler(IExchangeRateRepository repository) : IRequestHandler<GetExchangeRateByIdQuery, ExchangeRateDto>
{
    public async Task<ExchangeRateDto> Handle(GetExchangeRateByIdQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetByIdAsync(request.Id, cancellationToken);
    }
}