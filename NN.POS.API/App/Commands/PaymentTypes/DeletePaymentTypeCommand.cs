using MediatR;

namespace NN.POS.API.App.Commands.PaymentTypes;

public class DeletePaymentTypeCommand(int id) : IRequest
{
    public int Id => id;
}