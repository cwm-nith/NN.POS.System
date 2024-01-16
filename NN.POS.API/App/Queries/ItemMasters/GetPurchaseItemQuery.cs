using MediatR;
using NN.POS.Model.Dtos.Purchases;

namespace NN.POS.API.App.Queries.ItemMasters;

public class GetPurchaseItemQuery : IRequest<PurchaseItemDto>
{
    public int ItemId { get; set; }
    public int CcyId { get; set; }
    public int WsId { get; set; }
}