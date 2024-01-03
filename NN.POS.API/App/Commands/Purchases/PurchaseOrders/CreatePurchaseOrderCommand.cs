using MediatR;
using NN.POS.Model.Dtos.Purchases.PurchaseOrders;

namespace NN.POS.API.App.Commands.Purchases.PurchaseOrders;

public class CreatePurchaseOrderCommand(CreatePurchaseOrderDto dto) : IRequest
{
    public CreatePurchaseOrderDto Dto => dto;
}