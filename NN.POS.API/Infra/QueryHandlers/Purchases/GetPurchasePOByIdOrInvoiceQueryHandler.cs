using MediatR;
using NN.POS.API.App.Queries.Purchases;
using NN.POS.API.Core.IRepositories.Purchases;
using NN.POS.Model.Dtos.Purchases.PurchasePO;

namespace NN.POS.API.Infra.QueryHandlers.Purchases;

public class GetPurchasePOByIdOrInvoiceQueryHandler(IPurchasePORepository repository) : IRequestHandler<GetPurchasePOByIdOrInvoiceQuery, PurchasePODto>
{
    public async Task<PurchasePODto> Handle(GetPurchasePOByIdOrInvoiceQuery request, CancellationToken cancellationToken)
    {
        if (request.IsId) return await repository.GetByIdAsync((int)request.IdOrInvoice, cancellationToken);
        return await repository.GetByInvoiceNoAsync(request.IdOrInvoice?.ToString() ?? "", cancellationToken);
    }
}
