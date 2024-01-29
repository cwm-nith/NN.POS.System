using MediatR;
using NN.POS.Model.Dtos.Purchases.PurchasePO;

namespace NN.POS.API.App.Queries.Purchases;

public class GetPurchasePOByIdOrInvoiceQuery(object idOrInvoice, bool isId) : IRequest<PurchasePODto>
{
    public object IdOrInvoice => idOrInvoice;
    public bool IsId => isId;
}
