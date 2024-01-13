using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NN.POS.API.App.Queries.ItemMasters;
using NN.POS.API.Core.Exceptions.ItemMasters;
using NN.POS.API.Core.IRepositories.ItemMasters;
using NN.POS.API.Infra.Tables;
using NN.POS.API.Infra.Tables.ItemMasters;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.ItemMasters;
using NN.POS.Model.Enums;

namespace NN.POS.API.Infra.Repositories.ItemMasters;

public class ItemMasterDataRepository(
    IReadDbRepository<ItemMasterDataTable> readDbRepository,
    IWriteDbRepository<ItemMasterDataTable> writeDbRepository) : IItemMasterDataRepository
{
    public async Task<ItemMasterDataDto> CreateAsync(ItemMasterDataDto dto, CancellationToken cancellationToken = default)
    {
        var item = await writeDbRepository.AddAsync(dto.ToTable(), cancellationToken);
        return item.ToDto();
    }

    public async Task UpdateAsync(int id, UpdateItemMasterDataDto dto, CancellationToken cancellationToken = default)
    {
        var item = await GetByIdAsync(id, cancellationToken).ConfigureAwait(false);

        item.Name = dto.Name;
        item.OtherName = dto.OtherName;
        item.StockIn = dto.StockIn;
        item.StockCommit = dto.StockCommit;
        item.StockOnHand = dto.StockOnHand;
        item.BaseUomId = dto.BaseUomId;
        item.PriceListId = dto.PriceListId;
        item.UomGroupId = dto.UomGroupId;
        item.PurchaseUomId = dto.PurchaseUomId;
        item.SaleUomId = dto.SaleUomId;
        item.InventoryUoMid = dto.InventoryUoMid;
        item.WarehouseId = dto.WarehouseId;
        item.Type = dto.Type;
        item.IsInventory = dto.IsInventory;
        item.IsSale = dto.IsSale;
        item.IsPurchase = dto.IsPurchase;
        item.Description = dto.Description;
        item.Process = dto.Process;
        item.GroupId = dto.GroupId;

        await writeDbRepository.UpdateAsync(item.ToTable(), cancellationToken).ConfigureAwait(false);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var item = await GetByIdAsync(id, cancellationToken).ConfigureAwait(false);
        item.IsDeleted = true;
        await writeDbRepository.UpdateAsync(item.ToTable(), cancellationToken).ConfigureAwait(false);
    }

    public async Task<ItemMasterDataDto> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var context = readDbRepository.Context;
        var param = new SqlParameter("@id", id);

        var item = context.Database.SqlQuery<ItemMasterDataDto>($"EXECUTE dbo.select_item_master_data_by_id {param}")
                       .AsEnumerable().FirstOrDefault() ??
                   throw new ItemMasterDataNotFoundException(id);

        return await Task.FromResult(item);
    }

    public async Task<ItemMasterDataDto> GetByBarcodeAsync(string barcode, CancellationToken cancellationToken = default)
    {
        var item = await readDbRepository.FirstOrDefaultAsync(i => !i.IsDeleted && i.Barcode == barcode, cancellationToken) ??
                   throw new ItemMasterDataNotFoundException(barcode, true);
        return item.ToDto();
    }

    public async Task<ItemMasterDataDto> GetByCodeAsync(string code, CancellationToken cancellationToken = default)
    {
        var item = await readDbRepository.FirstOrDefaultAsync(i => !i.IsDeleted && i.Code == code, cancellationToken) ??
                   throw new ItemMasterDataNotFoundException(code, false);
        return item.ToDto();
    }

    public async Task<PagedResult<ItemMasterDataDto>> GetPageAsync(GetPageItemMasterDataQuery q, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(q.Search) && q is { Process: ItemMasterDataProcess.None, Type: ItemMasterDataType.None })
        {
            var item = await readDbRepository.BrowseAsync(i => !i.IsDeleted, i => i.Name, q, cancellationToken);
            return item.Map(i => i.ToDto());
        }

        if (!string.IsNullOrWhiteSpace(q.Search) && q is { Process: ItemMasterDataProcess.None, Type: ItemMasterDataType.None })
        {
            var item = await readDbRepository.BrowseAsync(i => !i.IsDeleted && EF.Functions.Like(i.Name, $"%{q.Search}%"), i => i.Name, q, cancellationToken);
            return item.Map(i => i.ToDto());
        }

        if (string.IsNullOrWhiteSpace(q.Search) && q.Process != ItemMasterDataProcess.None &&
            q.Type == ItemMasterDataType.None)
        {
            var item = await readDbRepository.BrowseAsync(i => !i.IsDeleted && i.Process == q.Process, i => i.Name, q,
                cancellationToken);
            return item.Map(i => i.ToDto());
        }

        if (!string.IsNullOrWhiteSpace(q.Search) && q.Process != ItemMasterDataProcess.None && q.Type == ItemMasterDataType.None)
        {
            var item = await readDbRepository.BrowseAsync(
                i =>
                    !i.IsDeleted
                    && i.Process == q.Process
                    && EF.Functions.Like(i.Name, $"%{q.Search}%"),
                i => i.Name, q, cancellationToken);
            return item.Map(i => i.ToDto());
        }

        if (!string.IsNullOrWhiteSpace(q.Search) && q.Process == ItemMasterDataProcess.None && q.Type != ItemMasterDataType.None)
        {
            var item = await readDbRepository.BrowseAsync(
                i =>
                    !i.IsDeleted
                    && i.Type == q.Type
                    && EF.Functions.Like(i.Name, $"%{q.Search}%"), i => i.Name, q, cancellationToken);
            return item.Map(i => i.ToDto());
        }

        if (string.IsNullOrWhiteSpace(q.Search) && q.Process == ItemMasterDataProcess.None && q.Type != ItemMasterDataType.None)
        {
            var item = await readDbRepository.BrowseAsync(
                i =>
                    !i.IsDeleted
                    && i.Type == q.Type,
                i => i.Name, q, cancellationToken);
            return item.Map(i => i.ToDto());
        }
        var itemMaster = await readDbRepository.BrowseAsync(i => !i.IsDeleted, i => i.Name, q, cancellationToken);
        return itemMaster.Map(i => i.ToDto());
    }
}