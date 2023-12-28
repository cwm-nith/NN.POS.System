using Microsoft.EntityFrameworkCore;
using NN.POS.API.App.Queries.PriceLists;
using NN.POS.API.Core.Exceptions.PriceLists;
using NN.POS.API.Core.IRepositories.PriceLists;
using NN.POS.API.Infra.Tables;
using NN.POS.API.Infra.Tables.PriceLists;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.PriceLists;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace NN.POS.API.Infra.Repositories.PriceLists;

public class PriceListRepository(
    IReadDbRepository<PriceListTable> readDbRepository,
    IWriteDbRepository<PriceListTable> writeDbRepository) : IPriceListRepository
{
    public async Task CreateAsync(PriceListDto dto, CancellationToken token = default)
    {
        await writeDbRepository.AddAsync(dto.ToTable(), token);
    }

    public async Task UpdateAsync(string? name, int id, CancellationToken cancellationToken = default)
    {
        var pl = await GetByIdAsync(id, cancellationToken);
        pl.Name = name ?? pl.Name;
        await writeDbRepository.UpdateAsync(pl.ToTable(), cancellationToken);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var pl = await GetByIdAsync(id, cancellationToken);
        pl.IsDeleted = true;
        await writeDbRepository.UpdateAsync(pl.ToTable(), cancellationToken);
    }

    public async Task<PriceListDto> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var data = await readDbRepository.FirstOrDefaultAsync(i => !i.IsDeleted && i.Id == id, cancellationToken) ??
                   throw new PriceListNotFoundException(id);
        return data.ToDto();
    }

    public async Task<PagedResult<PriceListDto>> GetPageAsync(GetPagePriceListQuery q, CancellationToken cancellationToken = default)
    {
        var context = readDbRepository.Context;
        var data = await (from pl in context.PriceLists!
                .Where(i => !i.IsDeleted && EF.Functions.Like(i.Name, $"%{q.Search}%"))
                       join ccy in context.Currencies on pl.CcyId equals ccy.Id
                       select pl.ToDto()).PaginateAsync(q, cancellationToken);

        return data;
    }
}