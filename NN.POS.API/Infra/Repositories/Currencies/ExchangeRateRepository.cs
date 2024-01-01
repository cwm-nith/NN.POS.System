using Microsoft.EntityFrameworkCore;
using NN.POS.API.App.Queries.Currencies;
using NN.POS.API.Core.Exceptions.Currencies;
using NN.POS.API.Core.IRepositories.Currencies;
using NN.POS.API.Infra.Tables;
using NN.POS.API.Infra.Tables.Currencies;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.Currencies;

namespace NN.POS.API.Infra.Repositories.Currencies;

public class ExchangeRateRepository(
    IReadDbRepository<ExchangeRateTable> readDbRepository,
    IWriteDbRepository<ExchangeRateTable> writeDbRepository,
    ICurrencyRepository ccyRepository) : IExchangeRateRepository
{
    public async Task CreateAsync(ExchangeRateDto exRate, CancellationToken cancellationToken = default)
    {
        await writeDbRepository.AddAsync(exRate.ToTable(), cancellationToken);
    }

    public async Task UpdateAsync(ExchangeRateDto exRate, CancellationToken cancellationToken = default)
    {
        await writeDbRepository.UpdateAsync(exRate.ToTable(), cancellationToken);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var exRate = await GetByIdAsync(id, cancellationToken);
        exRate.IsDeleted = true;
        await writeDbRepository.UpdateAsync(exRate.ToTable(), cancellationToken);
    }

    public async Task<ExchangeRateDto> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var baseCcy = await ccyRepository.GetBaseCurrencyAsync(cancellationToken);
        var context = readDbRepository.Context;
        var data = await (from ex in context.ExchangeRates!.Where(i => !i.IsDeleted && i.Id == id)
                          join ccy in context.Currencies! on ex.CcyId equals ccy.Id
                          select ex.ToDto(ccy.Name, baseCcy.Name)).FirstOrDefaultAsync(cancellationToken);
        return data ?? throw new ExchangeRateNotFoundException(id);
    }

    public async Task<PagedResult<ExchangeRateDto>> GetPageAsync(GetExchangeRatePageQuery query, CancellationToken cancellationToken = default)
    {
        var baseCcy = await ccyRepository.GetBaseCurrencyAsync(cancellationToken);
        var context = readDbRepository.Context;
        var data = await(from ex in context.ExchangeRates!.Where(i => !i.IsDeleted)
            join ccy in context.Currencies!.Where(i => !i.IsDeleted && EF.Functions.Like(i.Name, $"%{query.Search}%")) on ex.CcyId equals ccy.Id
            select ex.ToDto(ccy.Name, baseCcy.Name)).PaginateAsync(query, cancellationToken);
        return data;
    }
}