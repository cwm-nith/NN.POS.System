using MediatR;
using NN.POS.API.App.Queries.Purchases;
using NN.POS.API.Core.IRepositories.Purchases;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.Purchases.PurchaseOrders;

namespace NN.POS.API.Infra.QueryHandlers.Purchases;

public class GetPurchaseOrderPageQueryHandler(IPurchaseOrderRepository repository) : IRequestHandler<GetPurchaseOrderPageQuery, PagedResult<PurchaseOrderDto>>
{
    public async Task<PagedResult<PurchaseOrderDto>> Handle(GetPurchaseOrderPageQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetPageAsync(request, cancellationToken);
    }
}