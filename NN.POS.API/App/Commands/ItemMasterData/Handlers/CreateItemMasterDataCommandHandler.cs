using MediatR;
using NN.POS.API.Core.IRepositories.Currencies;
using NN.POS.API.Core.IRepositories.ItemMasters;
using NN.POS.API.Core.IRepositories.Warehouses;
using NN.POS.API.Core.Utils;
using NN.POS.Model.Dtos.ItemMasters;
using NN.POS.Model.Dtos.Warehouses;
using NN.POS.Model.Enums;

namespace NN.POS.API.App.Commands.ItemMasterData.Handlers;

public class CreateItemMasterDataCommandHandler(
    IItemMasterDataRepository repository, 
    IWebHostEnvironment environment,
    ILogger<CreateItemMasterDataCommandHandler> logger,
    ICurrencyRepository ccyRepository,
    IWarehouseSummaryRepository warehouseSummaryRepository) : IRequestHandler<CreateItemMasterDataCommand>
{
    public async Task Handle(CreateItemMasterDataCommand request, CancellationToken cancellationToken)
    {
        var isSuccess = false;
        var r = request.Dto;
        var fileName = r.File == null ? "" : $"{Guid.NewGuid()}{Path.GetExtension(r.File?.FileName)}";

        var dto = new ItemMasterDataDto
        {
            Code = StringUtil.GetRandomString(prefix: "item-"),
            Barcode = StringUtil.GetRandomString(prefix: "item-"),
            Name = r.Name,
            OtherName = r.OtherName,
            StockIn = r.StockIn,
            StockCommit = r.StockCommit,
            StockOnHand = r.StockOnHand,
            BaseUomId = r.BaseUomId,
            PriceListId = r.PriceListId,
            UomGroupId = r.UomGroupId,
            PurchaseUomId = r.PurchaseUomId,
            SaleUomId = r.SaleUomId,
            InventoryUoMid = r.InventoryUomId,
            WarehouseId = r.WarehouseId,
            Type = r.Type,
            IsInventory = r.IsInventory,
            IsSale = r.IsSale,
            IsPurchase = r.IsPurchase,
            Image = fileName,
            Description = r.Description,
            Process = r.Process,
            IsDeleted = false,
            CreatedAt = DateTime.UtcNow,
        };
        try
        {
            await repository.CreateAsync(dto, cancellationToken);

            if (r.File != null)
            {
                var uploadsPath = Path.Join(environment.WebRootPath, "contents/item-master/images");
                var filePath = Path.Join(uploadsPath, fileName);
                await using Stream fileStream = new FileStream(filePath, FileMode.Create);
                await fileStream.WriteAsync(r.File.ImageBytes, cancellationToken);
            }
            isSuccess = true;
        }
        catch (Exception e)
        {
            logger.LogError("Error while saving Item Master Data: {Error}", e.Message);
            throw;
        }
        finally
        {
            if (isSuccess)
            {
                var sysCcy = await ccyRepository.GetBaseCurrencyAsync(cancellationToken);
                if (r.Process != ItemMasterDataProcess.Standard)
                {
                    var warehouseSummary = new WarehouseSummaryDto
                    {
                        WarehouseId = r.WarehouseId,
                        ItemId = dto.Id,
                        InStock = 0,
                        ExpireDate = null,
                        UserId = request.UserId,
                        CcyId = sysCcy.Id,
                        UomId = dto.InventoryUoMid ?? 0,
                        Cost = 0,
                        AvailableStock = 0,
                        CommittedStock = 0,
                        OrderedStock = 0

                    };
                    await warehouseSummaryRepository.CreateAsync(warehouseSummary, cancellationToken);
                }
            }
        }
    }
}