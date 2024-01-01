using MediatR;
using NN.POS.Model.Dtos.PaymentTypes;

namespace NN.POS.API.App.Commands.PaymentTypes;

public class UpdatePaymentTypeCommand(int id, CreatePaymentTypeDto dto) : IRequest
{
    public int Id => id;
    public CreatePaymentTypeDto Dto => dto;
}