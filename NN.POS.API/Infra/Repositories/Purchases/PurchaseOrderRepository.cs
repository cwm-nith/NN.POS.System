using Microsoft.EntityFrameworkCore;
using NN.POS.API.App.Queries.Purchases;
using NN.POS.API.Core.Exceptions.Purchases;
using NN.POS.API.Core.IRepositories.Purchases;
using NN.POS.API.Infra.Tables;
using NN.POS.API.Infra.Tables.Purchases.PurchaseOrders;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.Purchases.PurchaseOrders;
using NN.POS.Model.Enums;

namespace NN.POS.API.Infra.Repositories.Purchases;

public class PurchaseOrderRepository(
    IReadDbRepository<PurchaseOrderTable> readDbRepository,
    IWriteDbRepository<PurchaseOrderTable> writeDbRepository) : IPurchaseOrderRepository
{
    public async Task Create(PurchaseOrderDto body, CancellationToken cancellationToken = default)
    {
        await writeDbRepository.AddAsync(body.ToTable(), cancellationToken);
    }

    public async Task Update(PurchaseOrderDto body, CancellationToken cancellationToken = default)
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
                              branchName: br.Name,
                              supplyName: supplier.ToString(),
                              sysCcyName: sysCcy.Name,
                              localCcyName: localCcy.Name,
                              wsName: ws.Name,
                              purCcyName: purCcy.Name,
                              userName: user.Name)).FirstOrDefaultAsync(cancellationToken);
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
                              branchName: br.Name,
                              supplyName: supplier.ToString(),
                              sysCcyName: sysCcy.Name,
                              localCcyName: localCcy.Name,
                              wsName: ws.Name,
                              purCcyName: purCcy.Name,
                              userName: user.Name)).FirstOrDefaultAsync(cancellationToken);
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
                              branchName: br.Name,
                              supplyName: supplier.ToString(),
                              sysCcyName: sysCcy.Name,
                              localCcyName: localCcy.Name,
                              wsName: ws.Name,
                              purCcyName: purCcy.Name,
                              userName: user.Name)).PaginateAsync(query, cancellationToken);
        return data;
    }
}