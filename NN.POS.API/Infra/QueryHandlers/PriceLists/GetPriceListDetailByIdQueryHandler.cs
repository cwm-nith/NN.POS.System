using MediatR;
using NN.POS.API.App.Queries.PriceLists;
using NN.POS.API.Core.IRepositories.PriceLists;
using NN.POS.Model.Dtos.PriceLists;

namespace NN.POS.API.Infra.QueryHandlers.PriceLists;

public class GetPriceListDetailByIdQueryHandler(IPriceListDetailRepository repository) : IRequestHandler<GetPriceListDetailByIdQuery, PriceListDetailDto>
{
    public async Task<PriceListDetailDto> Handle(GetPriceListDetailByIdQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetByIdAsync(request.Id, cancellationToken);
    }
}