using NN.POS.API.App.Queries.Purchases;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.Purchases.PurchaseCreditMemo;
using NN.POS.Model.Enums;

namespace NN.POS.API.Core.IRepositories.Purchases;

public interface IPurchaseCreditMemoRepository : IRepository
{
    Task CreateAsync(PurchaseCreditMemoDto body, PurchaseType purchaseType, CancellationToken cancellationToken = default);
    Task<PurchaseCreditMemoDto> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<PurchaseCreditMemoDto> GetByInvoiceNoAsync(string invoiceNo, CancellationToken cancellationToken = default);
    Task<PagedResult<PurchaseCreditMemoDto>> GetPageAsync(GetPurchaseCreditMemoPageQuery query, CancellationToken cancellationToken = default);

}
