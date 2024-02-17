using MediatR;
using NN.POS.Model.Dtos.Purchases.PurchaseCreditMemo;
using NN.POS.Model.Enums;

namespace NN.POS.API.App.Commands.Purchases.PurchaseCreditMemo;

public class CreatePurchaseCreditMemoCommand(int userId, CreatePurchaseCreditMemoDto dto) : IRequest<object>
{
    public int UserId => userId;
    public CreatePurchaseCreditMemoDto Dto => dto;
}
