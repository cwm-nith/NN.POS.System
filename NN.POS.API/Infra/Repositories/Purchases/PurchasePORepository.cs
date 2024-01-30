using NN.POS.API.App.Queries.Purchases;
using NN.POS.API.Core.IRepositories.Currencies;
using NN.POS.API.Core.IRepositories.DocumentInvoicing;
using NN.POS.API.Core.IRepositories.Purchases;
using NN.POS.API.Infra.Tables;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.Purchases.PurchasePO;
using NN.POS.API.Infra.Tables.Purchases.PurchasePO;
using Microsoft.EntityFrameworkCore;
using NN.POS.Model.Enums;
using NN.POS.Model.Dtos.DocumentInvoicings;
using NN.POS.Model.Dtos.Warehouses;
using NN.POS.API.Core.IRepositories.Warehouses;
using NN.POS.API.Core.IRepositories.Inventories;
using NN.POS.API.App.Queries.Inventories;
using NN.POS.Model.Dtos.Inventories;
using NN.POS.API.Core.IRepositories.PriceLists;
using NN.POS.API.Core.IRepositories.ItemMasters;
using NN.POS.API.Core.Exceptions.Purchases;
using NN.POS.API.Infra.Tables.Purchases.PurchaseOrders;

namespace NN.POS.API.Infra.Repositories.Purchases;

public class PurchasePORepository(
    IReadDbRepository<PurchasePOTable> readDbRepository,
    IWriteDbRepository<PurchasePOTable> writeDbRepository,
    ICurrencyRepository currencyRepository,
    ILogger<PurchasePORepository> logger,
    IWarehouseDetailRepository wsdRepo,
    IWarehouseSummaryRepository whsRepo,
    IInventoryAuditRepository invAuditRepo,
    IPriceListDetailRepository priceListRepo,
    IItemMasterDataRepository itemRepo,
    IDocumentInvoicingRepository documentInvoicingRepository,
    IDocumentInvoicePrefixingRepository documentInvoicePrefixingRepository) : DapperRepository<PurchasePORepository>(logger), IPurchasePORepository
{
    public async Task CreateAsync(PurchasePODto body, CancellationToken cancellationToken = default)
    {
        var context = writeDbRepository.Context;
        var localCcy = await currencyRepository.GetLocalCurrencyAsync(cancellationToken);
        var sysCcy = await currencyRepository.GetBaseCurrencyAsync(cancellationToken);

        var strategy = context.Database.CreateExecutionStrategy();
        await strategy.Execute(async () =>
        {
            await using var t = await context.Database.BeginTransactionAsync(cancellationToken);

            body.LocalCcyId = localCcy.Id;
            body.LocalSetRate = localCcy.ExchangeRate?.SetRate ?? 0;

            body.SysCcyId = sysCcy.Id;

            foreach (var pd in body.PurchasePODetails)
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

                    // TODO: check other type copy from

                    // update itmemasterdata
                    item.StockIn += qty;
                    //update warehouse
                    if (warehouse != null)
                    {
                        warehouse.InStock += qty;
                        await whsRepo.UpdateAsync(warehouse, cancellationToken);
                    }
                    await itemRepo.UpdateAsync(item, cancellationToken);

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
                            TransType = DocumentInvoicingType.PurchasePO,
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
                            TransType = DocumentInvoicingType.PurchasePO,
                            UserId = body.UserId
                        };

                        if(whs is not null)
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

            var purOrderTb = await writeDbRepository.AddAsync(body.ToTable(), cancellationToken);

            var prefix = await documentInvoicePrefixingRepository.GetAsync(DocumentInvoicingType.PurchasePO, cancellationToken);

            await documentInvoicingRepository.CreateAsync(new DocumentInvoicingDto
            {
                CreatedAt = DateTime.UtcNow,
                DocId = purOrderTb.Id,
                Id = 0,
                DocInvoicing = purOrderTb.InvoiceNo,
                InvoiceCount = 0,
                PreFix = prefix.Prefix,
                Type = DocumentInvoicingType.PurchasePO
            }, cancellationToken);

            await t.CommitAsync(cancellationToken);
        });
    }

    public async Task<PurchasePODto> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var context = readDbRepository.Context;
        var data = await (from po in context.PurchasePO!
                .Include(i => i.PurchasePODetails)
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
        return data ?? throw new PurchasePONotFoundException(id);
    }

    public async Task<PurchasePODto> GetByInvoiceNoAsync(string invoiceNo, CancellationToken cancellationToken = default)
    {
        var context = readDbRepository.Context;
        var data = await (from po in context.PurchasePO!
                .Include(i => i.PurchasePODetails)
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
        return data ?? throw new PurchasePONotFoundException(invoiceNo);
    }

    public async Task<PagedResult<PurchasePODto>> GetPageAsync(GetPurchasePOPageQuery query, CancellationToken cancellationToken = default)
    {
        var context = readDbRepository.Context;

        var data = await (from po in context.PurchasePO!
        .Include(i => i.PurchasePODetails)
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
