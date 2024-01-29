using NN.POS.API.App.Queries.Purchases;
using NN.POS.API.Core.IRepositories.Currencies;
using NN.POS.API.Core.IRepositories.DocumentInvoicing;
using NN.POS.API.Core.IRepositories.Purchases;
using NN.POS.API.Infra.Tables;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.Purchases.PurchasePO;
using NN.POS.API.Infra.Tables.Purchases.PurchasePO;
using NN.POS.API.Core;
using Microsoft.EntityFrameworkCore;
using NN.POS.Model.Enums;
using NN.POS.Model.Dtos.DocumentInvoicings;
using NN.POS.Model.Dtos.Warehouses;
using NN.POS.API.Core.IRepositories.Warehouses;

namespace NN.POS.API.Infra.Repositories.Purchases;

public class PurchasePORepository(
    IReadDbRepository<PurchasePOTable> readDbRepository,
    IWriteDbRepository<PurchasePOTable> writeDbRepository,
    ICurrencyRepository currencyRepository,
    ILogger<PurchasePORepository> logger,
    IWarehouseDetailRepository wsdRepo,
    IConfiguration configuration,
    IDocumentInvoicingRepository documentInvoicingRepository,
    IDocumentInvoicePrefixingRepository documentInvoicePrefixingRepository) : DapperRepository<PurchasePORepository>(logger), IPurchasePORepository
{
    private AppSettings AppSetting => configuration.GetSection("AppSetting").Get<AppSettings>() ?? new AppSettings();
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
                var item = await context.ItemMasterData!.FirstOrDefaultAsync(i => i.Id == pd.ItemId, cancellationToken);
                if(item != null)
                {
                    var gd = await context.UnitOfMeasureDefines!.FirstOrDefaultAsync(i => 
                    i.GroupUomId == item.UomGroupId && i.AltUomId == pd.UomId, cancellationToken);
                    var warehouse = await context.WarehouseSummaries!.FirstOrDefaultAsync(w => 
                    w.ItemId == pd.ItemId && w.WarehouseId == body.WarehouseId, cancellationToken);

                    var qty = pd.Qty * gd.Factor;
                    var cost = pd.PurchasePrice * gd.Factor * body.PurRate;

                    // TODO: check other type copy from

                    // update itmemasterdata
                    item.StockIn += qty;
                    //update warehouse
                    if(warehouse != null)
                    {
                        warehouse.InStock += qty;
                        context.WarehouseSummaries!.Update(warehouse);
                    }
                    context.ItemMasterData!.Update(item);

                    var wsd = new WarehouseDetailDto
                    {
                        AvailableStock = 0,
                        CcyId = body.PurCcyId,
                        CommittedStock = 0,
                        Cost = cost,
                        CreatedAt = DateTime.UtcNow,
                        ExpireDate = null,
                        Factor = gd.Factor,
                        Id = 0,
                        InStock = qty,
                        ItemId = item.Id,
                        OrderedStock = 0,
                        UomId = pd.UomId,
                        UserId = body.UserId,
                        WarehouseId = body.WarehouseId
                    };
                }
            }

            var purOrderTb = await writeDbRepository.AddAsync(body.ToTable(), cancellationToken);

            var prefix = await documentInvoicePrefixingRepository.GetAsync(DocumentInvoicingType.PurchaseOrder, cancellationToken);

            await documentInvoicingRepository.CreateAsync(new DocumentInvoicingDto
            {
                CreatedAt = DateTime.UtcNow,
                DocId = purOrderTb.Id,
                Id = 0,
                DocInvoicing = purOrderTb.InvoiceNo,
                InvoiceCount = 0,
                PreFix = prefix.Prefix,
                Type = DocumentInvoicingType.PurchaseOrder
            }, cancellationToken);

            await t.CommitAsync(cancellationToken);
        });
    }

    public Task<PurchasePODto> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<PurchasePODto> GetByInvoiceNoAsync(string invoiceNo, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<PagedResult<PurchasePODto>> GetPageAsync(GetPurchasePOPageQuery query, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
