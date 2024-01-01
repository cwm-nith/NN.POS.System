using MediatR;
using NN.POS.Model.Dtos.PaymentTypes;

namespace NN.POS.API.App.Queries.PaymentTypes;

public class GetPaymentTypeByIdQuery(int id) : IRequest<PaymentTypeDto>
{
    public int Id => id;
}