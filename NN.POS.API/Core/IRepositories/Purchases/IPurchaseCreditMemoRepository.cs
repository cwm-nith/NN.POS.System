using NN.POS.Model.Dtos.Purchases.PurchaseCreditMemo;
using NN.POS.Model.Enums;

namespace NN.POS.API.Core.IRepositories.Purchases;

public interface IPurchaseCreditMemoRepository
{
    Task CreateAsync(PurchaseCreditMemoDto body, PurchaseType purchaseType, CancellationToken cancellationToken = default);
}
