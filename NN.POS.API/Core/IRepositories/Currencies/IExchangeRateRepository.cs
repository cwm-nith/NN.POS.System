using NN.POS.API.App.Queries.Currencies;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.Currencies;

namespace NN.POS.API.Core.IRepositories.Currencies;

public interface IExchangeRateRepository : IRepository
{
    Task CreateAsync(ExchangeRateDto exRate, CancellationToken cancellationToken = default);
    Task UpdateAsync(ExchangeRateDto exRate, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    Task<ExchangeRateDto> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<PagedResult<ExchangeRateDto>> GetPageAsync(GetExchangeRatePageQuery query, CancellationToken cancellationToken = default);
}