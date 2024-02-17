using MediatR;
using NN.POS.API.App.Queries.Purchases;
using NN.POS.API.Core.IRepositories.Purchases;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.Purchases.PurchaseCreditMemo;

namespace NN.POS.API.Infra.QueryHandlers.Purchases;

public class GetPurchaseCreditMemoPageQueryHandler(IPurchaseCreditMemoRepository repository) : IRequestHandler<GetPurchaseCreditMemoPageQuery, PagedResult<PurchaseCreditMemoDto>>
{
    public async Task<PagedResult<PurchaseCreditMemoDto>> Handle(GetPurchaseCreditMemoPageQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetPageAsync(request, cancellationToken);
    }
}
