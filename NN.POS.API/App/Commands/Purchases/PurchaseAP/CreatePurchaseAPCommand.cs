using MediatR;
using NN.POS.Model.Dtos.Purchases.PurchaseAP;
using NN.POS.Model.Enums;

namespace NN.POS.API.App.Commands.Purchases.PurchaseAP;

public class CreatePurchaseAPCommand(int userId, CreatePurchaseAPDto dto) : IRequest
{
    public int UserId => userId;
    public CreatePurchaseAPDto Dto => dto;
}
