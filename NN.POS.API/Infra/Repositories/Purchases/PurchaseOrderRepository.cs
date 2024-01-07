using Microsoft.EntityFrameworkCore;
using NN.POS.API.App.Queries.Purchases;
using NN.POS.API.Core.Commons.Helpers;
using NN.POS.API.Core.Exceptions.Purchases;
using NN.POS.API.Core.IRepositories.Currencies;
using NN.POS.API.Core.IRepositories.Purchases;
using NN.POS.API.Infra.Tables;
using NN.POS.API.Infra.Tables.Purchases.PurchaseOrders;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.Purchases.PurchaseOrders;
using NN.POS.Model.Enums;

namespace NN.POS.API.Infra.Repositories.Purchases;

public class PurchaseOrderRepository(
    IReadDbRepository<PurchaseOrderTable> readDbRepository,
    IWriteDbRepository<PurchaseOrderTable> writeDbRepository,
    ICurrencyRepository currencyRepository) : IPurchaseOrderRepository
{
    public async Task CreateAsync(PurchaseOrderDto body, CancellationToken cancellationToken = default)
    {
        var context = writeDbRepository.Context;

        var (localCcy, sysCcy) = await TaskHelper.Run(
            currencyRepository.GetLocalCurrencyAsync(cancellationToken),
            currencyRepository.GetBaseCurrencyAsync(cancellationToken));

        await using var t = await context.Database.BeginTransactionAsync(cancellationToken);

        body.LocalCcyId = localCcy.Id;
        body.LocalSetRate = localCcy.ExchangeRate?.SetRate ?? 0;

        body.SysCcyId = sysCcy.Id;

        foreach (var pd in body.PurchaseOrderDetails)
        {
            await context.Database.ExecuteSqlAsync($"[dbo].[update_item_master_data_stock] @itemId={pd.ItemId}, @uomId={pd.UomId}, @wsId={body.WarehouseId}, @qty={pd.Qty}",cancellationToken);
        }

        await writeDbRepository.AddAsync(body.ToTable(), cancellationToken);

        await t.CommitAsync(cancellationToken);
    }

    public async Task UpdateAsync(PurchaseOrderDto body, CancellationToken cancellationToken = default)
    {
        await writeDbRepository.UpdateAsync(body.ToTable(), cancellationToken);
    }

    public async Task<PurchaseOrderDto> GetByInvoiceNoAsync(string invoiceNo, CancellationToken cancellationToken = default)
    {
        var context = readDbRepository.Context;
        var data = await (from pOrder in context.PurchaseOrders!
                .Include(i => i.PurchaseOrderDetails)
                .Where(i => i.Status == PurchaseStatus.Open && i.InvoiceNo == invoiceNo)
                          join br in context.Branches! on pOrder.BranchId equals br.Id
                          join supplier in context.BusinessPartners! on pOrder.SupplyId equals supplier.Id
                          join sysCcy in context.Currencies! on pOrder.SysCcyId equals sysCcy.Id
                          join localCcy in context.Currencies! on pOrder.LocalCcyId equals localCcy.Id
                          join ws in context.Warehouses! on pOrder.WarehouseId equals ws.Id
                          join purCcy in context.Currencies! on pOrder.PurCcyId equals purCcy.Id
                          join user in context.Users! on pOrder.UserId equals user.Id
                          select pOrder.ToDto(
                              br.Name,supplier.ToString(),sysCcy.Name, localCcy.Name,
                              ws.Name,purCcy.Name,user.Name)).FirstOrDefaultAsync(cancellationToken);
        return data ?? throw new PurchaseOrderNotFoundException(invoiceNo);
    }

    public async Task<PurchaseOrderDto> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var context = readDbRepository.Context;
        var data = await (from pOrder in context.PurchaseOrders!
                .Include(i => i.PurchaseOrderDetails)
                .Where(i => i.Status == PurchaseStatus.Open && i.Id == id)
                          join br in context.Branches! on pOrder.BranchId equals br.Id
                          join supplier in context.BusinessPartners! on pOrder.SupplyId equals supplier.Id
                          join sysCcy in context.Currencies! on pOrder.SysCcyId equals sysCcy.Id
                          join localCcy in context.Currencies! on pOrder.LocalCcyId equals localCcy.Id
                          join ws in context.Warehouses! on pOrder.WarehouseId equals ws.Id
                          join purCcy in context.Currencies! on pOrder.PurCcyId equals purCcy.Id
                          join user in context.Users! on pOrder.UserId equals user.Id
                          select pOrder.ToDto(
                              br.Name,
                              supplier.ToString(),
                              sysCcy.Name,
                              localCcy.Name,
                              ws.Name,
                              purCcy.Name,
                              user.Name)).FirstOrDefaultAsync(cancellationToken);
        return data ?? throw new PurchaseOrderNotFoundException(id);
    }

    public async Task<PagedResult<PurchaseOrderDto>> GetPageAsync(GetPurchaseOrderPageQuery query, CancellationToken cancellationToken = default)
    {
        var context = readDbRepository.Context;

        var data = await (from pOrder in context.PurchaseOrders!
        .Include(i => i.PurchaseOrderDetails)
                .Where(i =>
            (query.PurchaseStatus == null || i.Status == query.PurchaseStatus) &&
            (query.FromDate == null || query.ToDate == null || i.PostingDate >= query.FromDate && i.PostingDate <= query.ToDate) &&
            EF.Functions.Like(i.InvoiceNo, $"%{query.Search}%"))

                          join br in context.Branches! on pOrder.BranchId equals br.Id
                          join supplier in context.BusinessPartners! on pOrder.SupplyId equals supplier.Id
                          join sysCcy in context.Currencies! on pOrder.SysCcyId equals sysCcy.Id
                          join localCcy in context.Currencies! on pOrder.LocalCcyId equals localCcy.Id
                          join ws in context.Warehouses! on pOrder.WarehouseId equals ws.Id
                          join purCcy in context.Currencies! on pOrder.PurCcyId equals purCcy.Id
                          join user in context.Users! on pOrder.UserId equals user.Id
                          select pOrder.ToDto(
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