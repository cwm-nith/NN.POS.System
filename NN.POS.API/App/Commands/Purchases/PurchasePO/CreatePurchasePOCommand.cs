using MediatR;
using NN.POS.Model.Dtos.Purchases.PurchaseOrders;
using NN.POS.Model.Dtos.Purchases.PurchasePO;

namespace NN.POS.API.App.Commands.Purchases.PurchasePO;

public class CreatePurchasePOCommand(int userId, CreatePurchasePODto dto) : IRequest
{
    public int UserId => userId;
    public CreatePurchasePODto Dto => dto;
}