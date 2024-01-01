using NN.POS.API.App.Queries.Currencies;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.Currencies;

namespace NN.POS.API.Core.IRepositories.Currencies;

public interface ICurrencyRepository : IRepository
{
    Task CreateAsync(CurrencyDto ccy, CancellationToken cancellationToken= default);
    Task UpdateAsync(CurrencyDto ccy, CancellationToken cancellationToken= default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    Task<CurrencyDto> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<PagedResult<CurrencyDto>> GetPageAsync(GetCurrenciesPageQuery query, CancellationToken cancellationToken= default);
    Task<CurrencyDto> GetBaseCurrencyAsync(CancellationToken cancellationToken= default);
    Task<CurrencyDto> GetLocalCurrencyAsync(CancellationToken cancellationToken= default);
}