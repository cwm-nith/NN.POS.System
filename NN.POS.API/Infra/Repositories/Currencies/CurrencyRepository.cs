using NN.POS.API.App.Queries.Currencies;
using NN.POS.API.Core.IRepositories.Currencies;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.Currencies;

namespace NN.POS.API.Infra.Repositories.Currencies;

public class CurrencyRepository : ICurrencyRepository
{
    public Task CreateAsync(CurrencyDto ccy, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(CurrencyDto ccy, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<CurrencyDto> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<PagedResult<CurrencyDto>> GetPageAsync(GetCurrenciesPageQuery query, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}