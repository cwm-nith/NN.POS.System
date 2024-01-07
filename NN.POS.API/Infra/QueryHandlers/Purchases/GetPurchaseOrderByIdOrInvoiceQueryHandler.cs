using MediatR;
using NN.POS.API.App.Queries.Purchases;
using NN.POS.API.Core.IRepositories.Purchases;
using NN.POS.Model.Dtos.Purchases.PurchaseOrders;

namespace NN.POS.API.Infra.QueryHandlers.Purchases;

public class GetPurchaseOrderByIdOrInvoiceQueryHandler(IPurchaseOrderRepository repository) : IRequestHandler<GetPurchaseOrderByIdOrInvoiceQuery, PurchaseOrderDto>
{
    public async Task<PurchaseOrderDto> Handle(GetPurchaseOrderByIdOrInvoiceQuery request, CancellationToken cancellationToken)
    {
        if (request.IsId) return await repository.GetByIdAsync((int)request.IdOrInvoice, cancellationToken);
        return await repository.GetByInvoiceNoAsync(request.IdOrInvoice?.ToString() ?? "", cancellationToken);
    }
}