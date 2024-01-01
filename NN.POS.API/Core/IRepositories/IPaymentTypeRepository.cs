using NN.POS.API.App.Queries.PaymentTypes;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.PaymentTypes;

namespace NN.POS.API.Core.IRepositories;

public interface IPaymentTypeRepository : IRepository
{
    Task CreateAsync(PaymentTypeDto body, CancellationToken cancellationToken = default);
    Task UpdateAsync(PaymentTypeDto body, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    Task<PaymentTypeDto> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<PagedResult<PaymentTypeDto>> GetPageAsync(GetPaymentTypePageQuery query, CancellationToken cancellationToken = default);
}