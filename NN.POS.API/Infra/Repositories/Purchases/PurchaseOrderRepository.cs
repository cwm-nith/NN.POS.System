using NN.POS.API.Core.IRepositories.Purchases;
using NN.POS.API.Infra.Tables;
using NN.POS.API.Infra.Tables.Purchases.PurchaseOrders;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.Purchases.PurchaseOrders;

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
        return default;
    }

    public Task<PurchaseOrderDto> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<PagedResult<PurchaseOrderDto>> GetPageAsync(int id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}