using MediatR;
using NN.POS.Model.Dtos.Purchases.PurchaseAP;

namespace NN.POS.API.App.Queries.Purchases;

public class GetPurchaseAPByIdOrInvoiceQuery(object idOrInvoice, bool isId) : IRequest<PurchaseAPDto>
{
    public object IdOrInvoice => idOrInvoice;
    public bool IsId => isId;
}