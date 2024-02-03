using MediatR;
using NN.POS.API.App.Queries.Purchases;
using NN.POS.API.Core.IRepositories.Purchases;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.Purchases.PurchaseAP;

namespace NN.POS.API.Infra.QueryHandlers.Purchases;

public class GetPurchaseAPPageQueryHandler(IPurchaseAPRepository repository) : IRequestHandler<GetPurchaseAPPageQuery, PagedResult<PurchaseAPDto>>
{
    public Task<PagedResult<PurchaseAPDto>> Handle(GetPurchaseAPPageQuery request, CancellationToken cancellationToken)
    {
        return repository.GetPageAsync(request, cancellationToken);
    }
}
