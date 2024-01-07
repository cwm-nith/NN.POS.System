using NN.POS.API.App.Queries.PriceLists;
using NN.POS.API.Core.Exceptions.PriceLists;
using NN.POS.API.Core.IRepositories.PriceLists;
using NN.POS.API.Infra.Tables;
using NN.POS.API.Infra.Tables.PriceLists;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.PriceLists;
using NN.POS.Model.Enums;

namespace NN.POS.API.Infra.Repositories.PriceLists;

public class PriceListDetailRepository(
    IReadDbRepository<PriceListDetailTable> readDbRepository,
    IWriteDbRepository<PriceListDetailTable> writeDbRepository) : IPriceListDetailRepository
{
    public async Task CreateAsync(List<PriceListDetailDto> plDetails, CancellationToken cancellationToken = default)
    {
        await writeDbRepository.AddManyAsync(plDetails.Select(i => i.ToTable()).ToList(), cancellationToken);
    }

    public async Task UpdateAsync(PriceListDetailDto plDetail, CancellationToken cancellationToken = default)
    {
        await writeDbRepository.UpdateAsync(plDetail.ToTable(), cancellationToken);
    }

    public async Task<PagedResult<PriceListDetailDto>> GetPageAsync(GetPagePriceListDetailQuery q, CancellationToken cancellationToken = default)
    {
        var context = readDbRepository.Context;
        var data = await (from pld in context.PriceListDetails!.Where(i => i.PriceListId == q.PriceListId)
                          join item in context.ItemMasterData!.Where(
                              i => i.Type != ItemMasterDataType.Group && i.IsSale) on pld
                              .ItemId equals item.Id
                          join pl in context.PriceLists! on pld.PriceListId equals pl.Id
                          join ccy in context.Currencies! on pld.CcyId equals ccy.Id
                          join uom in context.UnitOfMeasures! on pld.UomId equals uom.Id
                          select pld.ToDto(pl.Name, ccy.Name, item, uom.Name)).PaginateAsync(q, cancellationToken);
        return data;
    }

    public async Task<PriceListDetailDto> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var data = await readDbRepository.FirstOrDefaultAsync(i => i.Id == id, cancellationToken) ?? throw new PriceListDetailNotFoundException(id);
        return data.ToDto();
    }
}