using MediatR;
using NN.POS.Model.Dtos.Purchases.PurchaseCreditMemo;

namespace NN.POS.API.App.Queries.Purchases;

public class GetPurchaseCreditMemoByIdOrInvoiceQuery(object idOrInvoice, bool isId) : IRequest<PurchaseCreditMemoDto>
{
    public object IdOrInvoice => idOrInvoice;
    public bool IsId => isId;
}