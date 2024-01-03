using MediatR;
using NN.POS.Model.Dtos.Purchases.PurchaseOrders;

namespace NN.POS.API.App.Queries.Purchases;

public class GetPurchaseOrderByIdOrInvoiceQuery(object idOrInvoice, bool isId) : IRequest<PurchaseOrderDto>
{
    public object IdOrInvoice => idOrInvoice;
    public bool IsId => isId;
}