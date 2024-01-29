using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NN.POS.API.App.Queries.PriceLists;
using NN.POS.API.Core;
using NN.POS.API.Core.Exceptions.PriceLists;
using NN.POS.API.Core.IRepositories.PriceLists;
using NN.POS.API.Core.Utils;
using NN.POS.API.Infra.Tables;
using NN.POS.API.Infra.Tables.Currencies;
using NN.POS.API.Infra.Tables.PriceLists;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.PriceLists;
using NN.POS.Model.Enums;

namespace NN.POS.API.Infra.Repositories.PriceLists;

public class PriceListDetailRepository(
    IReadDbRepository<PriceListDetailTable> readDbRepository,
    IWriteDbRepository<PriceListDetailTable> writeDbRepository,
    ILogger<PriceListDetailRepository> logger,
    IConfiguration configuration)
    : DapperRepository<PriceListDetailRepository>(logger), IPriceListDetailRepository
{
    private AppSettings AppSetting => configuration.GetSection("AppSetting").Get<AppSettings>() ?? new AppSettings();

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
        var data = await (from pld in context.PriceListDetails!
                .Where(i => i.PriceListId == q.PriceListId)
                          join item in context.ItemMasterData!.Where(
                              i => i.Type != ItemMasterDataType.Group && i.IsSale) on pld
                              .ItemId equals item.Id
                          join pl in context.PriceLists! on pld.PriceListId equals pl.Id
                          join ccy in context.Currencies! on pld.CcyId equals ccy.Id
                          join uom in context.UnitOfMeasures! on pld.UomId equals uom.Id
                          group new { pld, item, pl, ccy, uom } by item.Id into plds
                          select plds.FirstOrDefault()!.pld.ToDto(plds.FirstOrDefault()!.pl.Name, plds.FirstOrDefault()!.ccy.Name, plds.FirstOrDefault()!.item, plds.FirstOrDefault()!.uom.Name, null)).PaginateAsync(q, cancellationToken);
        return data;
    }

    public async Task<List<PriceListDetailDto>> GetAsync(int itemId, int uomId, CancellationToken cancellationToken = default)
    {
        var context = readDbRepository.Context;
        var data = await (from pld in context.PriceListDetails!
                .Where(i => i.ItemId == itemId && i.UomId == uomId)
                          join exRate in context.ExchangeRates! on pld.CcyId equals exRate.CcyId
                          select pld.ToDto(null, null, null, null, exRate.ToDto(null, null))).ToListAsync(cancellationToken);
        return data;
    }

    public async Task<PriceListDetailDto> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var data = await readDbRepository.FirstOrDefaultAsync(i => i.Id == id, cancellationToken) ?? throw new PriceListDetailNotFoundException(id);
        return data.ToDto();
    }

    public async Task<List<PriceListDetailDto>> GetCopyAsync(GetPriceListCopyQuery q, CancellationToken cancellationToken = default)
    {
        var con = (SqlConnection)CreateDbConnection(AppSetting.Database.ConnectionString);
        await using var cmd = (SqlCommand)CreateDbCommand(con, "[dbo].[get_copy_price_list]");
        cmd.Parameters.AddWithValue("@priceListId", q.PriceListId);
        cmd.Parameters.AddWithValue("@priceListIdCopyFrom", q.PriceListIdCopyFrom);
        var result = await ExecuteCommandQueryAsync(con, cmd, record => new PriceListDetailDto
        {
            Id = record["Id"].ToInt(),
            CreatedAt = record["CreatedAt"].ToDateTime(),
            CcyId = record["CcyId"].ToInt(),
            CcyName = record["CcyName"].ToString(),
            Cost = record["Cost"].ToDecimal(),
            DiscountType = (DiscountType)record["DiscountType"].ToInt(),
            DiscountValue = record["DiscountValue"].ToDecimal(),
            ItemBarcode = record["ItemBarcode"].ToString(),
            ItemId = record["ItemId"].ToInt(),
            ItemName = record["ItemName"].ToString(),
            ItemProcess = (ItemMasterDataProcess)record["ItemProcess"].ToInt(),
            Price = record["Price"].ToDecimal(),
            PriceListId = record["PriceListId"].ToInt(),
            PriceListName = record["PriceListName"].ToString(),
            PromotionId = record["PromotionId"].ToInt(),
            UomId = record["UomId"].ToInt(),
            UomName = record["UomName"].ToString()
        }, cancellationToken);

        return [.. result];

    }
}