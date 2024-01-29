using MediatR;
using NN.POS.API.App.Queries.Purchases;
using NN.POS.API.Core.IRepositories.Purchases;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.Purchases.PurchasePO;

namespace NN.POS.API.Infra.QueryHandlers.Purchases;

public class GetPurchasePOPageQueryHandler(IPurchasePORepository repository) : IRequestHandler<GetPurchasePOPageQuery, PagedResult<PurchasePODto>>
{
    public async Task<PagedResult<PurchasePODto>> Handle(GetPurchasePOPageQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetPageAsync(request, cancellationToken);
    }
}
