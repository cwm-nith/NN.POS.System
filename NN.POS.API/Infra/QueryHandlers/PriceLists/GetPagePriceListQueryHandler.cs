using MediatR;
using NN.POS.API.App.Queries.PriceLists;
using NN.POS.API.Core.IRepositories.PriceLists;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.PriceLists;

namespace NN.POS.API.Infra.QueryHandlers.PriceLists;

public class GetPagePriceListQueryHandler(IPriceListRepository repository) : IRequestHandler<GetPagePriceListQuery, PagedResult<PriceListDto>>
{
    public async Task<PagedResult<PriceListDto>> Handle(GetPagePriceListQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetPageAsync(request, cancellationToken);
    }
}