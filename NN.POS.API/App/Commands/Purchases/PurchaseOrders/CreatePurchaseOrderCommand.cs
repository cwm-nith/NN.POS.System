using MediatR;
using NN.POS.Model.Dtos.Purchases.PurchaseOrders;

namespace NN.POS.API.App.Commands.Purchases.PurchaseOrders;

public class CreatePurchaseOrderCommand(int userId, CreatePurchaseCreditMemoDto dto) : IRequest
{
    public int UserId => userId;
    public CreatePurchaseCreditMemoDto Dto => dto;
}