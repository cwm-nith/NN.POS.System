using NN.POS.API.App.Queries.Purchases;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.Purchases.PurchaseAP;
using NN.POS.Model.Enums;

namespace NN.POS.API.Core.IRepositories.Purchases;

public interface IPurchaseAPRepository : IRepository
{
    Task CreateAsync(PurchaseAPDto body, PurchaseType purchaseType, CancellationToken cancellationToken = default);
    Task<PurchaseAPDto> GetByInvoiceNoAsync(string invoiceNo, CancellationToken cancellationToken = default);
    Task<PurchaseAPDto> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<PagedResult<PurchaseAPDto>> GetPageAsync(GetPurchaseAPPageQuery query, CancellationToken cancellationToken = default);
}
