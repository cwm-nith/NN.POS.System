using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.Purchases.PurchaseOrders;

namespace NN.POS.API.Core.IRepositories.Purchases;

public interface IPurchaseOrderRepository : IRepository
{
    Task Create(PurchaseOrderDto body, CancellationToken cancellationToken = default);
    Task Update(PurchaseOrderDto body, CancellationToken cancellationToken = default);
    Task<PurchaseOrderDto> GetByInvoiceNoAsync(string invoiceNo, CancellationToken cancellationToken = default);
    Task<PurchaseOrderDto> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<PagedResult<PurchaseOrderDto>> GetPageAsync(int id, CancellationToken cancellationToken = default);
}