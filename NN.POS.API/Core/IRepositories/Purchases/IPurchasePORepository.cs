using NN.POS.API.App.Queries.Purchases;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.Purchases.PurchasePO;

namespace NN.POS.API.Core.IRepositories.Purchases;

public interface IPurchasePORepository : IRepository
{
    Task CreateAsync(PurchasePODto body, CancellationToken cancellationToken = default);
    Task<PurchasePODto> GetByInvoiceNoAsync(string invoiceNo, CancellationToken cancellationToken = default);
    Task<PurchasePODto> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<PagedResult<PurchasePODto>> GetPageAsync(GetPurchasePOPageQuery query, CancellationToken cancellationToken = default);
}