using MediatR;
using NN.POS.API.App.Queries.PriceLists;
using NN.POS.API.Core.IRepositories.PriceLists;
using NN.POS.Model.Dtos.PriceLists;

namespace NN.POS.API.Infra.QueryHandlers.PriceLists;

public class GetPriceListByIdQueryHandler(IPriceListRepository repository) : IRequestHandler<GetPriceListByIdQuery, PriceListDto>
{
    public async Task<PriceListDto> Handle(GetPriceListByIdQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetByIdAsync(request.Id, cancellationToken);
    }
}