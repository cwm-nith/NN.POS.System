using MediatR;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.PaymentTypes;

namespace NN.POS.API.App.Queries.PaymentTypes;

public class GetPaymentTypePageQuery : PagedQuery, IRequest<PagedResult<PaymentTypeDto>>
{
    public string? Search { get; set; }
}