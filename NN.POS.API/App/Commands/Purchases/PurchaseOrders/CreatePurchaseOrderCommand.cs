using MediatR;
using NN.POS.Model.Dtos.Purchases.PurchaseOrders;

namespace NN.POS.API.App.Commands.Purchases.PurchaseOrders;

public class CreatePurchaseOrderCommand(int userId, CreatePurchaseOrderDto dto) : IRequest
{
    public int UserId => userId;
    public CreatePurchaseOrderDto Dto => dto;
}