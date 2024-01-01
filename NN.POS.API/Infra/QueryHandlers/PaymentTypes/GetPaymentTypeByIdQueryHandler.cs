using MediatR;
using NN.POS.API.App.Queries.PaymentTypes;
using NN.POS.API.Core.IRepositories;
using NN.POS.Model.Dtos.PaymentTypes;

namespace NN.POS.API.Infra.QueryHandlers.PaymentTypes;

public class GetPaymentTypeByIdQueryHandler(IPaymentTypeRepository repository) : IRequestHandler<GetPaymentTypeByIdQuery, PaymentTypeDto>
{
    public async Task<PaymentTypeDto> Handle(GetPaymentTypeByIdQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetByIdAsync(request.Id, cancellationToken);
    }
}