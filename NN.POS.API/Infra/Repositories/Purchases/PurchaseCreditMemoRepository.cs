using NN.POS.API.Core.IRepositories.Currencies;
using NN.POS.API.Core.IRepositories.DocumentInvoicing;
using NN.POS.API.Core.IRepositories.Inventories;
using NN.POS.API.Core.IRepositories.ItemMasters;
using NN.POS.API.Core.IRepositories.PriceLists;
using NN.POS.API.Core.IRepositories.Warehouses;
using NN.POS.API.Infra.Tables;
using NN.POS.Model.Dtos.Purchases.PurchaseCreditMemo;
using NN.POS.API.Infra.Tables.Purchases.PurchaseCreditMemo;
using Microsoft.EntityFrameworkCore;
using NN.POS.Model.Enums;
using NN.POS.API.Infra.Tables.Purchases.PurchasePO;
using NN.POS.API.App.Queries.Inventories;
using NN.POS.Model.Dtos.DocumentInvoicings;
using NN.POS.Model.Dtos.Inventories;
using NN.POS.Model.Dtos.Warehouses;
using NN.POS.API.Core.IRepositories.OutGoingVendors;
using NN.POS.Model.Dtos.OutGoingPayments;
using NN.POS.API.Core.Utils;
using NN.POS.API.Core.IRepositories.Purchases;
using NN.POS.API.Infra.Tables.ItemMasters;
using NN.POS.API.Infra.Tables.Warehouses;
using NN.POS.API.Infra.Tables.PriceLists;
using NN.POS.API.Infra.Tables.Inventories;
using NN.POS.API.Infra.Tables.OutGoingPayments;
using NN.POS.API.Infra.Tables.DocumentInvoicing;
using NN.POS.API.Infra.Tables.Purchases.PurchaseAP;

namespace NN.POS.API.Infra.Repositories.Purchases;

#pragma warning disable S3267 // Loops should be simplified with "LINQ" expressions
public class PurchaseCreditMemoRepository(
    IReadDbRepository<PurchaseCreditMemoTable> readDbRepository,
    IWriteDbRepository<PurchaseCreditMemoTable> writeDbRepository,
    ICurrencyRepository currencyRepository,
    IWarehouseDetailRepository wsdRepo,
    IWarehouseSummaryRepository whsRepo,
    IInventoryAuditRepository invAuditRepo,
    IPriceListDetailRepository priceListRepo,
    IItemMasterDataRepository itemRepo,
    IDocumentInvoicingRepository documentInvoicingRepository,
    IDocumentInvoicePrefixingRepository documentInvoicePrefixingRepository,
    IOutGoingPaymentSupplierRepository outGoingPaymentSupplierRepo,
    IPurchaseAPRepository purchaseAPRepo) : IPurchaseCreditMemoRepository
{
    public async Task CreateAsync(PurchaseCreditMemoDto body, PurchaseType purchaseType, CancellationToken cancellationToken = default)
    {
        var context = writeDbRepository.Context;
        PurchaseCreditMemoTable? purCreditMemoTb = new();
        var strategy = context.Database.CreateExecutionStrategy();
        await strategy.Execute(async () =>
        {
            await using var t = await context.Database.BeginTransactionAsync(cancellationToken);


            if (purchaseType == PurchaseType.PurchaseCreditMemo)
            {
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
                    DocumentType = DocumentInvoicingType.PurchaseCreditMemo,
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
                await context.OutGoingPaymentSuppliers!.AddAsync(outgoingPayment.ToTable(), cancellationToken);
                var localCcy = await currencyRepository.GetLocalCurrencyAsync(cancellationToken);
                var sysCcy = await currencyRepository.GetBaseCurrencyAsync(cancellationToken);

                body.LocalCcyId = localCcy.Id;
                body.LocalSetRate = localCcy.ExchangeRate?.SetRate ?? 0;

                body.SysCcyId = sysCcy.Id;
                purCreditMemoTb = await CreatePurchaseCreditMemoInternalAsync(context, body, purchaseType, cancellationToken);
            }
            else if (purchaseType == PurchaseType.PurchaseAP)
            {
                var outgoingPayment = new OutGoingPaymentSupplierDto
                {
                    AppliedAmount = body.BalanceDue,
                    BalanceDue = 0,
                    BranchId = body.BranchId,
                    Cash = 0,
                    CcyId = body.PurCcyId,
                    CreatedAt = DateTime.UtcNow,
                    Date = body.DueDate,
                    DiscountType = body.DiscountType,
                    DiscountValue = 0,
                    DocumentType = DocumentInvoicingType.PurchaseCreditMemo,
                    ExchangeRate = body.PurRate,
                    Id = 0,
                    InvoiceNo = body.InvoiceNo,
                    LocalCcyId = body.LocalCcyId,
                    LocalSetRate = body.LocalSetRate,
                    OverdueDays = 0,
                    PostingDate = body.PostingDate,
                    Status = PurchaseStatus.Close,
                    SupplierId = body.SupplyId,
                    SysCcyId = body.SysCcyId,
                    Total = 0,
                    TotalPayment = 0,
                    WarehouseId = body.WarehouseId
                };
                await context.OutGoingPaymentSuppliers!.AddAsync(outgoingPayment.ToTable(), cancellationToken);

                var purAp = await purchaseAPRepo.GetByIdAsync(purCreditMemoTb.CopyFromId, cancellationToken);
                if (purAp is not null)
                {

                    var balance = purAp.BalanceDue - body.BalanceDue;
                    var balanceSys = purAp.BalanceDueSys - body.BalanceDueSys;
                    purAp.AppliedAmount += body.BalanceDue;
                    purAp.BalanceDue = balance;
                    purAp.BalanceDueSys = balanceSys;
                    if (purAp.AppliedAmount >= outgoingPayment.AppliedAmount)
                    {
                        purAp.Status = PurchaseStatus.Close;
                    }
                    context.PurchaseAP!.Update(purAp.ToTable());

                    var outPaymentAP = await outGoingPaymentSupplierRepo.GetAsync(purAp.InvoiceNo, DocumentInvoicingType.PurchaseAP);
                    if (outPaymentAP is not null)
                    {
                        var balanceOutAp = outPaymentAP.BalanceDue - body.BalanceDue;
                        outPaymentAP.BalanceDue = balanceOutAp;
                        outPaymentAP.AppliedAmount += body.BalanceDue;
                        outPaymentAP.Cash = balanceOutAp;
                        if (outPaymentAP.AppliedAmount == outgoingPayment.AppliedAmount)
                        {
                            outPaymentAP.Status = PurchaseStatus.Close;
                        }
                        context.OutGoingPaymentSuppliers!.Update(outPaymentAP.ToTable());
                    }
                }

                if (body.AppliedAmount == body.BalanceDue)
                {
                    body.Status = PurchaseStatus.Close;
                    body.BalanceDue = 0;
                    body.BalanceDueSys = 0;
                }

                purCreditMemoTb = await CreatePurchaseCreditMemoInternalAsync(context, body, purchaseType, cancellationToken);


                foreach (var check in body.PurchaseCreditMemoDetails)
                {
                    if(purAp is not null)
                    {
                        //check close AP
                        var purchaseDetail = purAp.PurchaseAPDetails.Find(w => w.Id == check.CopyFromId);
                        if(purchaseDetail is not null)
                        {
                            var open_qty = purchaseDetail.OpenQty - check.Qty;
                            purchaseDetail.OpenQty = open_qty;
                            purchaseDetail.IsDeleted = open_qty <= 0;
                            
                            context.PurchaseAPDetail!.Update(purchaseDetail.ToTable());
                        }
                    }
                }
            }

            if (purCreditMemoTb is not null)
            {
                var prefix = await documentInvoicePrefixingRepository.GetAsync(DocumentInvoicingType.PurchaseCreditMemo, cancellationToken);

                await context.DocumentInvoicing!.AddAsync(new DocumentInvoicingDto
                {
                    CreatedAt = DateTime.UtcNow,
                    DocId = purCreditMemoTb.Id,
                    Id = 0,
                    DocInvoicing = purCreditMemoTb.InvoiceNo,
                    InvoiceCount = 0,
                    PreFix = prefix.Prefix,
                    Type = DocumentInvoicingType.PurchaseCreditMemo
                }.ToTable(), cancellationToken);
            }

            await t.CommitAsync(cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
        });
    }

    //public async Task<PurchaseCreditMemoDto> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    //{
    //    var context = readDbRepository.Context;
    //    var data = await (from po in context.PurchaseCreditMemos!
    //            .Include(i => i.PurchaseCreditMemoDetails)
    //            .Where(i => i.Status == PurchaseStatus.Open && i.Id == id)
    //                      join br in context.Branches! on po.BranchId equals br.Id
    //                      join supplier in context.BusinessPartners! on po.SupplyId equals supplier.Id
    //                      join sysCcy in context.Currencies! on po.SysCcyId equals sysCcy.Id
    //                      join localCcy in context.Currencies! on po.LocalCcyId equals localCcy.Id
    //                      join ws in context.Warehouses! on po.WarehouseId equals ws.Id
    //                      join purCcy in context.Currencies! on po.PurCcyId equals purCcy.Id
    //                      join user in context.Users! on po.UserId equals user.Id
    //                      select po.ToDto(
    //                          br.Name,
    //                          supplier.ToString(),
    //                          sysCcy.Name,
    //                          localCcy.Name,
    //                          ws.Name,
    //                          purCcy.Name,
    //                          user.Name)).FirstOrDefaultAsync(cancellationToken);
    //    return data ?? throw new PurchaseCreditMemoNotFoundException(id);
    //}

    //public async Task<PurchaseCreditMemoDto> GetByInvoiceNoAsync(string invoiceNo, CancellationToken cancellationToken = default)
    //{
    //    var context = readDbRepository.Context;
    //    var data = await (from po in context.PurchaseCreditMemo!
    //            .Include(i => i.PurchaseCreditMemoDetails)
    //            .Where(i => i.Status == PurchaseStatus.Open && i.InvoiceNo == invoiceNo)
    //                      join br in context.Branches! on po.BranchId equals br.Id
    //                      join supplier in context.BusinessPartners! on po.SupplyId equals supplier.Id
    //                      join sysCcy in context.Currencies! on po.SysCcyId equals sysCcy.Id
    //                      join localCcy in context.Currencies! on po.LocalCcyId equals localCcy.Id
    //                      join ws in context.Warehouses! on po.WarehouseId equals ws.Id
    //                      join purCcy in context.Currencies! on po.PurCcyId equals purCcy.Id
    //                      join user in context.Users! on po.UserId equals user.Id
    //                      select po.ToDto(
    //                          br.Name, supplier.ToString(), sysCcy.Name, localCcy.Name,
    //                          ws.Name, purCcy.Name, user.Name)).FirstOrDefaultAsync(cancellationToken);
    //    return data ?? throw new PurchaseCreditMemoNotFoundException(invoiceNo);
    //}

    //public async Task<PagedResult<PurchaseCreditMemoDto>> GetPageAsync(GetPurchaseCreditMemoPageQuery query, CancellationToken cancellationToken = default)
    //{
    //    var context = readDbRepository.Context;

    //    var data = await (from po in context.PurchaseCreditMemo!
    //    .Include(i => i.PurchaseCreditMemoDetails)
    //            .Where(i =>
    //        (query.PurchaseStatus == null || i.Status == query.PurchaseStatus) &&
    //        (query.FromDate == null || query.ToDate == null || i.PostingDate >= query.FromDate && i.PostingDate <= query.ToDate) &&
    //        EF.Functions.Like(i.InvoiceNo, $"%{query.Search}%"))

    //                      join br in context.Branches! on po.BranchId equals br.Id
    //                      join supplier in context.BusinessPartners! on po.SupplyId equals supplier.Id
    //                      join sysCcy in context.Currencies! on po.SysCcyId equals sysCcy.Id
    //                      join localCcy in context.Currencies! on po.LocalCcyId equals localCcy.Id
    //                      join ws in context.Warehouses! on po.WarehouseId equals ws.Id
    //                      join purCcy in context.Currencies! on po.PurCcyId equals purCcy.Id
    //                      join user in context.Users! on po.UserId equals user.Id
    //                      select po.ToDto(
    //                          br.Name,
    //                          supplier.ToString(),
    //                          sysCcy.Name,
    //                          localCcy.Name,
    //                          ws.Name,
    //                          purCcy.Name,
    //                          user.Name)).PaginateAsync(query, cancellationToken);
    //    return data;
    //}

    private async Task<PurchaseCreditMemoTable> CreatePurchaseCreditMemoInternalAsync(
        DataDbContext context,
        PurchaseCreditMemoDto body,
        PurchaseType purchaseType,
        CancellationToken cancellationToken)
    {
        foreach (var pd in body.PurchaseCreditMemoDetails)
        {
            var item = await itemRepo.GetByIdAsync(pd.ItemId, cancellationToken);
            if (item != null)
            {
                var gd = await context.UnitOfMeasureDefines!.FirstOrDefaultAsync(i =>
                i.GroupUomId == item.UomGroupId && i.AltUomId == pd.UomId, cancellationToken);
                var warehouseSm = await whsRepo.GetAsync(pd.ItemId, body.WarehouseId, cancellationToken);

                var qty = pd.Qty * (gd?.Factor ?? 0) * -1;
                var cost = pd.PurchasePrice * (gd?.Factor ?? 0) * body.PurRate;

                var invAudit = new InventoryAuditDto();
                var wsd = new WarehouseDetailDto();

                if (purchaseType == PurchaseType.PurchaseCreditMemo)
                {
                    // update itmemasterdata
                    item.StockIn += qty;
                    //update warehouse
                    if (warehouseSm != null)
                    {
                        warehouseSm.InStock += qty;
                    }
                }

                context.ItemMasterData!.Update(item.ToTable());
                if (warehouseSm is not null) context.WarehouseSummaries!.Update(warehouseSm.ToTable());

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
                        TransType = DocumentInvoicingType.PurchaseCreditMemo,
                        UserId = body.UserId
                    };
                    foreach (var pri in priDetails)
                    {
                        pri.Cost = cost * (pri.ExchangeRate?.SetRate ?? 0);
                        context.PriceListDetails!.Update(pri.ToTable());
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
                        TransType = DocumentInvoicingType.PurchaseCreditMemo,
                        UserId = body.UserId
                    };

                    if (whs is not null)
                    {
                        // update_warehouse_summary
                        whs.Cost = avgCost;
                        context.WarehouseSummaries!.Update(whs.ToTable());
                    }

                    foreach (var pri in priDetails)
                    {
                        pri.Cost = avgCost * (pri.ExchangeRate?.SetRate ?? 0);
                        context.PriceListDetails!.Update(pri.ToTable());
                    }
                }

                await context.WarehouseDetails!.AddAsync(wsd.ToTable(), cancellationToken);
                await context.InventoryAudits!.AddAsync(invAudit.ToTable(), cancellationToken);
            }
        }
        return await writeDbRepository.AddAsync(body.ToTable(), cancellationToken);
    }
}
