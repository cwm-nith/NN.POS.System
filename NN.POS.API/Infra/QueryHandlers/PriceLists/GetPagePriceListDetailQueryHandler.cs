using MediatR;
using NN.POS.API.App.Queries.PriceLists;
using NN.POS.API.Core.IRepositories.PriceLists;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.PriceLists;

namespace NN.POS.API.Infra.QueryHandlers.PriceLists;

public class GetPagePriceListDetailQueryHandler(IPriceListDetailRepository repository) : IRequestHandler<GetPagePriceListDetailQuery, PagedResult<PriceListDetailDto>>
{
    public async Task<PagedResult<PriceListDetailDto>> Handle(GetPagePriceListDetailQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetPageAsync(request, cancellationToken);
    }
}