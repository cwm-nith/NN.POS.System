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
        var context = readDbRepository.Context;
        var curr = await (from ccy in context.Currencies!
                .Where(i => !i.IsDeleted && (string.IsNullOrEmpty(query.Search) || EF.Functions.Like(i.Name, $"%{query.Search}%")))
            join ex in context.ExchangeRates!.Where(i => !i.IsDeleted) on ccy.Id equals ex.CcyId
            select ccy.ToDto(ex)).PaginateAsync(query, cancellationToken);
        return curr;
    }

    public async Task<CurrencyDto> GetBaseCurrencyAsync(CancellationToken cancellationToken = default)
    {
        var context = readDbRepository.Context;
        var baseCurr = await (from ccy in context.Currencies!.Where(i => !i.IsDeleted)
                              join com in context.Companies!.Where(i => !i.IsDeleted) on ccy.Id equals com.SysCcyId
                              join ex in context.ExchangeRates!.Where(i => !i.IsDeleted) on ccy.Id equals ex.CcyId
                              select ccy.ToDto(ex)).FirstOrDefaultAsync(cancellationToken);

        return baseCurr ?? throw new BaseCurrencyNotFoundException();
    }

    public async Task<CurrencyDto> GetLocalCurrencyAsync(CancellationToken cancellationToken = default)
    {
        var context = readDbRepository.Context;
        var baseCurr = await (from ccy in context.Currencies!.Where(i => !i.IsDeleted)
                              join com in context.Companies!.Where(i => !i.IsDeleted) on ccy.Id equals com.LocalCcyId
                              join ex in context.ExchangeRates!.Where(i => !i.IsDeleted) on ccy.Id equals ex.CcyId
                              select ccy.ToDto(ex)).FirstOrDefaultAsync(cancellationToken);

        return baseCurr ?? throw new LocalCurrencyNotFoundException();
    }
}