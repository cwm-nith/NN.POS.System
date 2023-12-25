using Microsoft.EntityFrameworkCore;
using NN.POS.API.App.Queries.Currencies;
using NN.POS.API.Core.Exceptions.Currencies;
using NN.POS.API.Core.IRepositories.Currencies;
using NN.POS.API.Infra.Tables;
using NN.POS.API.Infra.Tables.Currencies;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.Currencies;

namespace NN.POS.API.Infra.Repositories.Currencies;

public class CurrencyRepository(
    IReadDbRepository<CurrencyTable> readDbRepository, 
    IWriteDbRepository<CurrencyTable> writeDbRepository) : ICurrencyRepository
{
    public async Task CreateAsync(CurrencyDto ccy, CancellationToken cancellationToken = default)
    {
        await writeDbRepository.AddAsync(ccy.ToTable(), cancellationToken);
    }

    public async Task UpdateAsync(CurrencyDto ccy, CancellationToken cancellationToken = default)
    {
        await writeDbRepository.UpdateAsync(ccy.ToTable(), cancellationToken);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var ccy = await GetByIdAsync(id, cancellationToken);
        ccy.IsDeleted = true;
        await writeDbRepository.UpdateAsync(ccy.ToTable(), cancellationToken);
    }

    public async Task<CurrencyDto> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var ccy = await readDbRepository.FirstOrDefaultAsync(i => !i.IsDeleted && i.Id == id, cancellationToken) ??
                  throw new CurrencyNotFoundException(id);
        return ccy.ToDto();
    }

    public async Task<PagedResult<CurrencyDto>> GetPageAsync(GetCurrenciesPageQuery query, CancellationToken cancellationToken = default)
    {
        PagedResult<CurrencyTable> data;

        if (string.IsNullOrWhiteSpace(query.Search))
        {
            data = await readDbRepository.BrowseAsync(i => !i.IsDeleted, query, cancellationToken);
        }
        else
        {
            data = await readDbRepository.BrowseAsync(i => 
                !i.IsDeleted && EF.Functions.Like(i.Name, $"%{query.Search}%"), 
                query, 
                cancellationToken);
        }

        return data.Map(i => i.ToDto());
    }
}