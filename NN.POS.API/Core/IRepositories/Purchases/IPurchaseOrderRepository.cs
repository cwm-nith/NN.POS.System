using NN.POS.API.App.Queries.Purchases;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.Purchases.PurchaseOrders;

namespace NN.POS.API.Core.IRepositories.Purchases;

public interface IPurchaseOrderRepository : IRepository
{
    Task CreateAsync(PurchaseOrderDto body, CancellationToken cancellationToken = default);
    Task UpdateAsync(PurchaseOrderDto body, CancellationToken cancellationToken = default);
    Task<PurchaseOrderDto> GetByInvoiceNoAsync(string invoiceNo, CancellationToken cancellationToken = default);
    Task<PurchaseOrderDto> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<PagedResult<PurchaseOrderDto>> GetPageAsync(GetPurchaseOrderPageQuery query, CancellationToken cancellationToken = default);
}