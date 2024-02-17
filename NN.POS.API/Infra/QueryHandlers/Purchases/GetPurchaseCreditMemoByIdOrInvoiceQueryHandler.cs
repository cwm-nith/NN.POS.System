using MediatR;
using NN.POS.API.App.Queries.Purchases;
using NN.POS.API.Core.IRepositories.Purchases;
using NN.POS.Model.Dtos.Purchases.PurchaseCreditMemo;

namespace NN.POS.API.Infra.QueryHandlers.Purchases;

public class GetPurchaseCreditMemoByIdOrInvoiceQueryHandler(IPurchaseCreditMemoRepository repository) : IRequestHandler<GetPurchaseCreditMemoByIdOrInvoiceQuery, PurchaseCreditMemoDto>
{
    public async Task<PurchaseCreditMemoDto> Handle(GetPurchaseCreditMemoByIdOrInvoiceQuery request, CancellationToken cancellationToken)
    {
        if (request.IsId) return await repository.GetByIdAsync((int)request.IdOrInvoice, cancellationToken);

        return await repository.GetByInvoiceNoAsync(request.IdOrInvoice?.ToString() ?? "", cancellationToken);
    }
}
