using NN.POS.API.App.Queries.Purchases;
using NN.POS.API.Core.IRepositories.Currencies;
using NN.POS.API.Core.IRepositories.DocumentInvoicing;
using NN.POS.API.Core.IRepositories.Inventories;
using NN.POS.API.Core.IRepositories.ItemMasters;
using NN.POS.API.Core.IRepositories.PriceLists;
using NN.POS.API.Core.IRepositories.Purchases;
using NN.POS.API.Core.IRepositories.Warehouses;
using NN.POS.API.Infra.Tables;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.Purchases.PurchaseAP;
using NN.POS.API.Infra.Tables.Purchases.PurchaseAP;
using Microsoft.EntityFrameworkCore;
using NN.POS.API.Core.Exceptions.Purchases;
using NN.POS.Model.Enums;
using NN.POS.API.Infra.Tables.Purchases.PurchasePO;
using NN.POS.API.App.Queries.Inventories;
using NN.POS.Model.Dtos.DocumentInvoicings;
using NN.POS.Model.Dtos.Inventories;
using NN.POS.Model.Dtos.Warehouses;
using NN.POS.API.Core.IRepositories.OutGoingVendors;
using NN.POS.Model.Dtos.OutGoingPayments;
using NN.POS.API.Core.Utils;

namespace NN.POS.API.Infra.Repositories.Purchases;

public class PurchaseAPRepository(
    IReadDbRepository<PurchaseAPTable> readDbRepository,
    IWriteDbRepository<PurchaseAPTable> writeDbRepository,
    ICurrencyRepository currencyRepository,
    IWarehouseDetailRepository wsdRepo,
    IWarehouseSummaryRepository whsRepo,
    IInventoryAuditRepository invAuditRepo,
    IPriceListDetailRepository priceListRepo,
    IItemMasterDataRepository itemRepo,
    IDocumentInvoicingRepository documentInvoicingRepository,
    IDocumentInvoicePrefixingRepository documentInvoicePrefixingRepository,
    IOutGoingPaymentSupplierRepository outGoingPaymentSupplierRepo) : IPurchaseAPRepository
{
    public async Task CreateAsync(PurchaseAPDto body, PurchaseType purchaseType, CancellationToken cancellationToken = default)
    {
        var context = writeDbRepository.Context;
        PurchaseAPTable? purOrderTb = new();

        await using var t = await context.Database.BeginTransactionAsync(cancellationToken);

        if (purchaseType != PurchaseType.PurchasePO)
        {
            var strategy = context.Database.CreateExecutionStrategy();
            await strategy.Execute(async () =>
            {
                if(purchaseType == PurchaseType.PurchaseAP)
                {
                    var localCcy = await currencyRepository.GetLocalCurrencyAsync(cancellationToken);
                    var sysCcy = await currencyRepository.GetBaseCurrencyAsync(cancellationToken);

                    body.LocalCcyId = localCcy.Id;
                    body.LocalSetRate = localCcy.ExchangeRate?.SetRate ?? 0;

                    body.SysCcyId = sysCcy.Id;
                }                

                foreach (var pd in body.PurchaseAPDetails)
                {
                    var item = await itemRepo.GetByIdAsync(pd.ItemId, cancellationToken);
                    if (item != null)
                    {
                        var gd = await context.UnitOfMeasureDefines!.FirstOrDefaultAsync(i =>
                        i.GroupUomId == item.UomGroupId && i.AltUomId == pd.UomId, cancellationToken);
                        var warehouse = await whsRepo.GetAsync(pd.ItemId, body.WarehouseId, cancellationToken);

                        var qty = pd.Qty * (gd?.Factor ?? 0);
                        var cost = pd.PurchasePrice * (gd?.Factor ?? 0) * body.PurRate;

                        var invAudit = new InventoryAuditDto();
                        var wsd = new WarehouseDetailDto();

                        if (purchaseType == PurchaseType.PurchaseOrder)
                        {
                            // update itmemasterdata
                            item.StockOnHand -= qty;
                            item.StockIn += qty;
                            //update warehouse
                            if (warehouse != null)
                            {
                                warehouse.OrderedStock -= qty;
                                warehouse.InStock += qty;
                            }
                        }

                        if (purchaseType == PurchaseType.PurchaseAP)
                        {
                            // update itmemasterdata
                            item.StockIn += qty;
                            //update warehouse
                            if (warehouse != null)
                            {
                                warehouse.InStock += qty;
                            }
                        }

                        await itemRepo.UpdateAsync(item, cancellationToken);
                        if(warehouse is not null) await whsRepo.UpdateAsync(warehouse, cancellationToken);

                        wsd = new WarehouseDetailDto
                        {
                            AvailableStock = 0,
                            CcyId = body.PurCcyId,
                            CommittedStock = 0,
                            Cost = cost,
                            CreatedAt = DateTime.UtcNow,
                            ExpireDate = null,
                            Factor = gd?.Factor ?? 0,
                            Id = 0,
                            InStock = qty,
                            ItemId = item.Id,
                            OrderedStock = 0,
                            UomId = pd.UomId,
                            UserId = body.UserId,
                            WarehouseId = body.WarehouseId
                        };

                        var priDetails = await priceListRepo.GetAsync(pd.ItemId, pd.UomId, cancellationToken);
                        var invAudits = await invAuditRepo.GetAsync(new GetInventoryAuditQuery
                        {
                            WarehouseId = body.WarehouseId,
                            UomId = pd.UomId,
                            ItemId = pd.ItemId
                        }, cancellationToken);

                        if (item.Process == ItemMasterDataProcess.Fifo)
                        {
                            invAudit = new InventoryAuditDto
                            {
                                ItemId = pd.ItemId,
                                UomId = pd.UomId,
                                WarehouseId = body.WarehouseId,
                                BranchId = body.BranchId,
                                CcyId = body.SysCcyId,
                                Cost = cost,
                                CreatedAt = DateTime.UtcNow,
                                ExpireDate = null,
                                CumulativeQty = invAudits.Sum(i => i.Qty) + qty,
                                Qty = qty,
                                CumulativeValue = invAudits.Sum(i => i.TransValue) + (qty * cost),
                                TransValue = qty * cost,
                                Price = 0,
                                Id = 0,
                                InvoiceNo = body.InvoiceNo,
                                LocalCcyId = body.LocalCcyId,
                                LocalSetRate = body.LocalSetRate,
                                Process = item.Process,
                                TransType = DocumentInvoicingType.PurchaseAP,
                                UserId = body.UserId
                            };
                            foreach (var pri in priDetails)
                            {
                                pri.Cost = cost * (pri.ExchangeRate?.SetRate ?? 0);
                                await priceListRepo.UpdateAsync(pri, cancellationToken);
                            }
                        }
                        else
                        {
                            var whs = await whsRepo.GetAsync(body.WarehouseId, pd.ItemId, cancellationToken);
                            var avgCost = ((invAudits.Sum(s => s.TransValue)) + (qty * cost)) / (invAudits.Sum(q => q.Qty) + qty);
                            invAudit = new InventoryAuditDto
                            {
                                ItemId = pd.ItemId,
                                UomId = pd.UomId,
                                WarehouseId = body.WarehouseId,
                                BranchId = body.BranchId,
                                CcyId = body.SysCcyId,
                                Cost = avgCost,
                                CreatedAt = DateTime.UtcNow,
                                ExpireDate = null,
                                CumulativeQty = invAudits.Sum(i => i.Qty) + qty,
                                Qty = qty,
                                CumulativeValue = invAudits.Sum(i => i.TransValue) + (qty * avgCost),
                                TransValue = qty * avgCost,
                                Price = 0,
                                Id = 0,
                                InvoiceNo = body.InvoiceNo,
                                LocalCcyId = body.LocalCcyId,
                                LocalSetRate = body.LocalSetRate,
                                Process = item.Process,
                                TransType = DocumentInvoicingType.PurchaseAP,
                                UserId = body.UserId
                            };

                            if (whs is not null)
                            {
                                // update_warehouse_summary
                                whs.Cost = avgCost;
                                await whsRepo.UpdateAsync(whs, cancellationToken);
                            }

                            foreach (var pri in priDetails)
                            {
                                pri.Cost = avgCost * (pri.ExchangeRate?.SetRate ?? 0);
                                await priceListRepo.UpdateAsync(pri, cancellationToken);
                            }
                        }

                        await wsdRepo.CreateAsync(wsd, cancellationToken);
                        await invAuditRepo.CreateAsync(invAudit, cancellationToken);
                    }
                }

                purOrderTb = await writeDbRepository.AddAsync(body.ToTable(), cancellationToken);
                
            });
        }
        else
        {
            purOrderTb = await writeDbRepository.AddAsync(body.ToTable(), cancellationToken);
        }

        var outgoingPayment = new OutGoingPaymentSupplierDto
        {
            AppliedAmount = body.AppliedAmount,
            BalanceDue = body.BalanceDue,
            BranchId = body.BranchId,
            Cash = body.BalanceDue,
            CcyId = body.PurCcyId,
            CreatedAt = DateTime.UtcNow,
            Date = body.DueDate,
            DiscountType = body.DiscountType,
            DiscountValue = 0,
            DocumentType = DocumentInvoicingType.PurchaseAP,
            ExchangeRate = body.PurRate,
            Id = 0,
            InvoiceNo = body.InvoiceNo,
            LocalCcyId = body.LocalCcyId,
            LocalSetRate = body.LocalSetRate,
            OverdueDays = (DateTime.UtcNow - body.DueDate).TotalDays.ToDecimal(),
            PostingDate = body.PostingDate,
            Status = body.Status,
            SupplierId = body.SupplyId,
            SysCcyId = body.SysCcyId,
            Total = body.SubTotal,
            TotalPayment = body.SubTotal - (body.DiscountType == DiscountType.Flat ? body.DiscountValue : body.SubTotal * body.DiscountValue / 100),
            WarehouseId = body.WarehouseId
        };

        await outGoingPaymentSupplierRepo.CreateAsync(outgoingPayment, cancellationToken);

        if(purOrderTb is not null)
        {
            var prefix = await documentInvoicePrefixingRepository.GetAsync(DocumentInvoicingType.PurchaseAP, cancellationToken);

            await documentInvoicingRepository.CreateAsync(new DocumentInvoicingDto
            {
                CreatedAt = DateTime.UtcNow,
                DocId = purOrderTb.Id,
                Id = 0,
                DocInvoicing = purOrderTb.InvoiceNo,
                InvoiceCount = 0,
                PreFix = prefix.Prefix,
                Type = DocumentInvoicingType.PurchaseAP
            }, cancellationToken);
        }

        await t.CommitAsync(cancellationToken);
    }

    public async Task<PurchaseAPDto> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var context = readDbRepository.Context;
        var data = await (from po in context.PurchaseAP!
                .Include(i => i.PurchaseAPDetails)
                .Where(i => i.Status == PurchaseStatus.Open && i.Id == id)
                          join br in context.Branches! on po.BranchId equals br.Id
                          join supplier in context.BusinessPartners! on po.SupplyId equals supplier.Id
                          join sysCcy in context.Currencies! on po.SysCcyId equals sysCcy.Id
                          join localCcy in context.Currencies! on po.LocalCcyId equals localCcy.Id
                          join ws in context.Warehouses! on po.WarehouseId equals ws.Id
                          join purCcy in context.Currencies! on po.PurCcyId equals purCcy.Id
                          join user in context.Users! on po.UserId equals user.Id
                          select po.ToDto(
                              br.Name,
                              supplier.ToString(),
                              sysCcy.Name,
                              localCcy.Name,
                              ws.Name,
                              purCcy.Name,
                              user.Name)).FirstOrDefaultAsync(cancellationToken);
        return data ?? throw new PurchaseAPNotFoundException(id);
    }

    public async Task<PurchaseAPDto> GetByInvoiceNoAsync(string invoiceNo, CancellationToken cancellationToken = default)
    {
        var context = readDbRepository.Context;
        var data = await (from po in context.PurchaseAP!
                .Include(i => i.PurchaseAPDetails)
                .Where(i => i.Status == PurchaseStatus.Open && i.InvoiceNo == invoiceNo)
                          join br in context.Branches! on po.BranchId equals br.Id
                          join supplier in context.BusinessPartners! on po.SupplyId equals supplier.Id
                          join sysCcy in context.Currencies! on po.SysCcyId equals sysCcy.Id
                          join localCcy in context.Currencies! on po.LocalCcyId equals localCcy.Id
                          join ws in context.Warehouses! on po.WarehouseId equals ws.Id
                          join purCcy in context.Currencies! on po.PurCcyId equals purCcy.Id
                          join user in context.Users! on po.UserId equals user.Id
                          select po.ToDto(
                              br.Name, supplier.ToString(), sysCcy.Name, localCcy.Name,
                              ws.Name, purCcy.Name, user.Name)).FirstOrDefaultAsync(cancellationToken);
        return data ?? throw new PurchaseAPNotFoundException(invoiceNo);
    }

    public async Task<PagedResult<PurchaseAPDto>> GetPageAsync(GetPurchaseAPPageQuery query, CancellationToken cancellationToken = default)
    {
        var context = readDbRepository.Context;

        var data = await (from po in context.PurchaseAP!
        .Include(i => i.PurchaseAPDetails)
                .Where(i =>
            (query.PurchaseStatus == null || i.Status == query.PurchaseStatus) &&
            (query.FromDate == null || query.ToDate == null || i.PostingDate >= query.FromDate && i.PostingDate <= query.ToDate) &&
            EF.Functions.Like(i.InvoiceNo, $"%{query.Search}%"))

                          join br in context.Branches! on po.BranchId equals br.Id
                          join supplier in context.BusinessPartners! on po.SupplyId equals supplier.Id
                          join sysCcy in context.Currencies! on po.SysCcyId equals sysCcy.Id
                          join localCcy in context.Currencies! on po.LocalCcyId equals localCcy.Id
                          join ws in context.Warehouses! on po.WarehouseId equals ws.Id
                          join purCcy in context.Currencies! on po.PurCcyId equals purCcy.Id
                          join user in context.Users! on po.UserId equals user.Id
                          select po.ToDto(
                              br.Name,
                              supplier.ToString(),
                              sysCcy.Name,
                              localCcy.Name,
                              ws.Name,
                              purCcy.Name,
                              user.Name)).PaginateAsync(query, cancellationToken);
        return data;
    }
}
