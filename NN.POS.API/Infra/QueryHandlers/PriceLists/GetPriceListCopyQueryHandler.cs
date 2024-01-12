using MediatR;
using NN.POS.API.App.Queries.PriceLists;
using NN.POS.API.Core.IRepositories.PriceLists;
using NN.POS.Model.Dtos.PriceLists;

namespace NN.POS.API.Infra.QueryHandlers.PriceLists;

public class GetPriceListCopyQueryHandler(IPriceListDetailRepository repository) : IRequestHandler<GetPriceListCopyQuery, List<PriceListDetailDto>>
{
    public async Task<List<PriceListDetailDto>> Handle(GetPriceListCopyQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetCopyAsync(request, cancellationToken);
    }
}