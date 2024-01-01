using MediatR;
using NN.POS.Model.Dtos.PaymentTypes;

namespace NN.POS.API.App.Commands.PaymentTypes;

public class CreatePaymentTypeCommand(CreatePaymentTypeDto dto) : IRequest
{
    public CreatePaymentTypeDto Dto => dto;
}