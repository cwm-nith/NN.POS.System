using MediatR;
using NN.POS.API.App.Queries.Purchases;
using NN.POS.API.Core.Exceptions.Purchases;
using NN.POS.API.Core.IRepositories.Purchases;
using NN.POS.Model.Dtos.Purchases.PurchaseAP;

namespace NN.POS.API.Infra.QueryHandlers.Purchases;

public class GetPurchaseAPByIdOrInvoiceQueryHandler(IPurchaseAPRepository repository) : IRequestHandler<GetPurchaseAPByIdOrInvoiceQuery, PurchaseAPDto>
{
    public async Task<PurchaseAPDto> Handle(GetPurchaseAPByIdOrInvoiceQuery request, CancellationToken cancellationToken)
    {
        if (request.IsId) return await repository.GetByIdAsync((int)request.IdOrInvoice, cancellationToken) 
                ?? throw new PurchaseAPNotFoundException((int)request.IdOrInvoice);

        return await repository.GetByInvoiceNoAsync(request.IdOrInvoice?.ToString() ?? "", cancellationToken);
    }
}
