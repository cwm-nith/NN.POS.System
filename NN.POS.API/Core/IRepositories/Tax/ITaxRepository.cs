using NN.POS.API.App.Queries.Tax;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.Tax;

namespace NN.POS.API.Core.IRepositories.Tax;

public interface ITaxRepository : IRepository
{
    Task CreateAsync(TaxDto body, CancellationToken cancellationToken = default);
    Task UpdateAsync(TaxDto body, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    Task<TaxDto> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<PagedResult<TaxDto>> GetPageAsync(GetTaxPageQuery query, CancellationToken cancellationToken = default);
}