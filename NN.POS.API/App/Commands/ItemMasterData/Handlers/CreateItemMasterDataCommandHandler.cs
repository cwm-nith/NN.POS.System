using MediatR;
using NN.POS.API.Core.IRepositories.Currencies;
using NN.POS.API.Core.IRepositories.ItemMasters;
using NN.POS.API.Core.IRepositories.PriceLists;
using NN.POS.API.Core.IRepositories.UnitOfMeasures;
using NN.POS.API.Core.IRepositories.Warehouses;
using NN.POS.API.Core.Utils;
using NN.POS.Model.Dtos.ItemMasters;
using NN.POS.Model.Dtos.PriceLists;
using NN.POS.Model.Dtos.Warehouses;
using NN.POS.Model.Enums;

namespace NN.POS.API.App.Commands.ItemMasterData.Handlers;

public class CreateItemMasterDataCommandHandler(
    IItemMasterDataRepository repository,
    IWebHostEnvironment environment,
    ILogger<CreateItemMasterDataCommandHandler> logger,
    ICurrencyRepository ccyRepository,
    IWarehouseSummaryRepository warehouseSummaryRepository,
    IPriceListRepository priceListRepository,
    IPriceListDetailRepository priceListDetailRepository,
    IUnitOfMeasureDefineRepository uomDefineRepository,
    IWarehouseDetailRepository warehouseDetailRepository) : IRequestHandler<CreateItemMasterDataCommand>
{
    public async Task Handle(CreateItemMasterDataCommand request, CancellationToken cancellationToken)
    {
        var isSuccess = false;
        var r = request.Dto;
        var fileName = r.File == null ? "" : $"{Guid.NewGuid()}{Path.GetExtension(r.File?.FileName)}";

        var itemMasterData = new ItemMasterDataDto();
        
        try
        {
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
            itemMasterData = await repository.CreateAsync(dto, cancellationToken);

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
                var priceList = await priceListRepository.GetByIdAsync(r.PriceListId, cancellationToken);
                var uomDefines = (await uomDefineRepository.GetUomDefineByGroupIdAsync(itemMasterData.UomGroupId)).ToList();
                if (r.Process != ItemMasterDataProcess.Standard)
                {
                    var warehouseSummary = new WarehouseSummaryDto
                    {
                        WarehouseId = r.WarehouseId,
                        ItemId = itemMasterData.Id,
                        InStock = 0,
                        ExpireDate = null,
                        UserId = request.UserId,
                        CcyId = sysCcy.Id,
                        UomId = itemMasterData.InventoryUoMid ?? 0,
                        Cost = 0,
                        AvailableStock = 0,
                        CommittedStock = 0,
                        OrderedStock = 0,
                        CreatedAt = DateTime.UtcNow
                    };
                    await warehouseSummaryRepository.CreateAsync(warehouseSummary, cancellationToken);
                }

                var pld = new List<PriceListDetailDto>();

                foreach (var item in uomDefines)
                {
                    //Standard
                    if (r.Process == ItemMasterDataProcess.Standard)
                    {
                        if (item.AltUomId == r.SaleUomId)
                        {
                            pld.Add(new PriceListDetailDto
                            {
                                UomId = r.SaleUomId,
                                CcyId = priceList.CcyId,
                                ItemId = itemMasterData.Id,
                                PriceListId = r.PriceListId,
                                Cost = 0,
                                Price = 0,
                                CreatedAt = DateTime.UtcNow,
                                DiscountType = DiscountType.Percentage,
                                DiscountValue = 0
                            });
                        }
                        else
                        {
                            pld.Add(new PriceListDetailDto
                            {
                                UomId = item.AltUomId,
                                CcyId = priceList.CcyId,
                                ItemId = itemMasterData.Id,
                                PriceListId = r.PriceListId,
                                Cost = 0,
                                Price = 0,
                                CreatedAt = DateTime.UtcNow,
                                DiscountType = DiscountType.Percentage,
                                DiscountValue = 0
                            });
                        }

                    }
                    //FIFO, Average
                    else
                    {

                        if (item.AltUomId == r.SaleUomId)
                        {
                            pld.Add(new PriceListDetailDto
                            {
                                UomId = r.SaleUomId,
                                CcyId = priceList.CcyId,
                                ItemId = itemMasterData.Id,
                                PriceListId = r.PriceListId,
                                Cost = 0,
                                Price = 0,
                                CreatedAt = DateTime.UtcNow,
                                DiscountType = DiscountType.Percentage,
                                DiscountValue = 0
                            });
                        }
                        else
                        {
                            pld.Add(new PriceListDetailDto
                            {
                                UomId = item.AltUomId,
                                CcyId = priceList.CcyId,
                                ItemId = itemMasterData.Id,
                                PriceListId = r.PriceListId,
                                Cost = 0,
                                Price = 0,
                                CreatedAt = DateTime.UtcNow,
                                DiscountType = DiscountType.Percentage,
                                DiscountValue = 0
                            });
                        }
                        
                        //Insert to warehouse detail
                        var warehouseDetail = new WarehouseDetailDto
                        {
                            WarehouseId = r.WarehouseId,
                            ItemId = itemMasterData.Id,
                            InStock = 0,
                            ExpireDate = null,
                            UserId = request.UserId,
                            CcyId = sysCcy.Id,
                            UomId = item.AltUomId,
                            Cost = 0,
                            AvailableStock = 0,
                            CommittedStock = 0,
                            OrderedStock = 0,
                            CreatedAt = DateTime.UtcNow,
                            Factor = item.Factor
                        };
                        await warehouseDetailRepository.CreateAsync(warehouseDetail, cancellationToken);
                    }
                }

                await priceListDetailRepository.CreateAsync(pld, cancellationToken);
            }
        }
    }
}