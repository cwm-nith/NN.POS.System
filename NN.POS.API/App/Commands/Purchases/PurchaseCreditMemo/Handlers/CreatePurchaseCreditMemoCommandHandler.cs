using MediatR;
using NN.POS.API.Core.IRepositories.ItemMasters;
using NN.POS.API.Core.IRepositories.Purchases;
using NN.POS.API.Core.IRepositories.UnitOfMeasures;
using NN.POS.API.Core.IRepositories.Warehouses;
using NN.POS.Model.Dtos.Purchases;
using NN.POS.Model.Dtos.Purchases.PurchaseCreditMemo;

namespace NN.POS.API.App.Commands.Purchases.PurchaseCreditMemo.Handlers;

public class CreatePurchaseCreditMemoCommandHandler(
    IPurchaseCreditMemoRepository repository,
    IItemMasterDataRepository itemRepo,
    IUnitOfMeasureDefineRepository udRepo,
    IWarehouseSummaryRepository wsRepo,
    IWarehouseDetailRepository wdRepo,
    IUnitOfMeasureRepository uomRepo) : IRequestHandler<CreatePurchaseCreditMemoCommand, object>
{
    public async Task<object> Handle(CreatePurchaseCreditMemoCommand request, CancellationToken cancellationToken)
    {
        var r = request.Dto;
        var dto = new PurchaseCreditMemoDto
        {
            AppliedAmount = r.AppliedAmount,
            BalanceDue = r.BalanceDue,
            BalanceDueSys = r.BalanceDueSys,
            BaseOn = r.BaseOn,
            BaseOnId = r.BaseOnId,
            BranchId = r.BranchId,
            CopyFromId = r.CopyFromId,
            CreatedAt = DateTime.UtcNow,
            DiscountType = r.DiscountType,
            DiscountValue = r.DiscountValue,
            DocumentDate = r.DocumentDate ?? DateTime.UtcNow,
            DownPayment = r.DownPayment,
            DueDate = r.DueDate ?? DateTime.UtcNow,
            Id = 0,
            InvoiceNo = r.InvoiceNo,
            LocalCcyId = r.LocalCcyId,
            LocalSetRate = r.LocalSetRate,
            PostingDate = r.PostingDate ?? DateTime.UtcNow,
            PurCcyId = r.PurCcyId,
            PurchaseCreditMemoDetails = r.PurchaseCreditMemoDetails.Select(i => new PurchaseCreditMemoDetailDto
            {
                CopyFromId = i.CopyFromId,
                CreatedAt = DateTime.UtcNow,
                DiscountType = i.DiscountType,
                DiscountValue = i.DiscountValue,
                IsDeleted = false,
                ItemId = i.ItemId,
                LocalCcyId = i.LocalCcyId,
                PurchasePrice = i.PurchasePrice,
                Qty = i.Qty,
                Total = i.Total,
                TotalSys = i.TotalSys,
                UomId = i.UomId
            }).ToList(),
            PurRate = r.PurRate,
            Remark = r.Remark,
            ReturnAmount = r.ReturnAmount,
            Status = r.Status,
            SubTotal = r.SubTotal,
            SubTotalSys = r.SubTotalSys,
            SupplyId = r.SupplyId,
            SysCcyId = r.SysCcyId,
            TaxRate = r.TaxRate,
            TaxValue = r.TaxValue,
            UserId = request.UserId,
            WarehouseId = r.WarehouseId
        };

        var itemReturns = new List<ItemOutOfStockOrNotYetPurchaseDto>();
        var itemNotYetPurchaseReturns = new List<ItemOutOfStockOrNotYetPurchaseDto>();

        foreach (var item in dto.PurchaseCreditMemoDetails)
        {
            var itemMaster = await itemRepo.GetByIdAsync(item.ItemId, cancellationToken);
            var gd = await udRepo.GetAsync(i => i.GroupUomId == itemMaster.UomGroupId && i.AltUomId == item.UomId, cancellationToken);
            if(gd is not null)
            {
                var checkItem = itemReturns.Find(i => i.ItemId == item.ItemId);
                if (checkItem == null)
                {
                    var ws = await wsRepo.GetAsync(dto.WarehouseId, item.ItemId, cancellationToken);
                    itemReturns.Add(new ItemOutOfStockOrNotYetPurchaseDto
                    {
                        Code = itemMaster.Code,
                        ItemId = item.ItemId,
                        ItemName = itemMaster.Name + ' ' + itemMaster.InventoryUoMName,
                        InStock = (ws?.InStock ?? 0) - (ws?.CommittedStock ?? 0),
                        OrderQty = item.Qty * gd.Factor,
                        Committed = ws?.CommittedStock ?? 0
                    });
                }
                else
                {
                    checkItem.OrderQty += item.Qty * gd.Factor;
                }

                var itemNotYetPurchase = await wdRepo.GetAsync(
                    w => w.ItemId == item.ItemId
                    && w.UomId == item.UomId
                    && w.Cost == (item.PurchasePrice * dto.PurRate) * gd.Factor
                    && w.InStock >= item.Qty * gd.Factor, cancellationToken);

                if (itemNotYetPurchase == null)
                {
                    var uom = await uomRepo.GetByIdAsync(item.UomId, cancellationToken);
                    itemNotYetPurchaseReturns.Add(new ItemOutOfStockOrNotYetPurchaseDto
                    {
                        Code = itemMaster.Code,
                        ItemId = item.ItemId,
                        ItemName = itemMaster.Name + ' ' + uom?.Name,
                        InStock = 0,
                        OrderQty = 0,
                        Committed = 0
                    });
                }
            }
        }

        itemReturns = itemReturns.Where(i => i.OrderQty > i.InStock).ToList();

        if (itemReturns.Count > 0)
        {
            return new
            {
                itemReturns,
                itemNotYetPurchaseReturns
            };
        }

        await repository.CreateAsync(dto, r.Type, cancellationToken);
        return null!;
    }
}
