using MediatR;
using NN.POS.API.App.Queries.PaymentTypes;
using NN.POS.API.Core.IRepositories;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.PaymentTypes;

namespace NN.POS.API.Infra.QueryHandlers.PaymentTypes;

public class GetPaymentTypePageQueryHandler(IPaymentTypeRepository repository) : IRequestHandler<GetPaymentTypePageQuery, PagedResult<PaymentTypeDto>>
{
    public async Task<PagedResult<PaymentTypeDto>> Handle(GetPaymentTypePageQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetPageAsync(request, cancellationToken);
    }
}