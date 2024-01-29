using NN.POS.API.App.Queries.Inventories;
using NN.POS.API.Core.IRepositories.Inventories;
using NN.POS.API.Infra.Tables.Purchases.PurchasePO;
using NN.POS.API.Infra.Tables;
using NN.POS.Model.Dtos.Inventories;
using NN.POS.API.Infra.Tables.Inventories;

namespace NN.POS.API.Infra.Repositories.Inventories;

public class InventoryAuditRepository(
    IReadDbRepository<InventoryAuditTable> readDbRepository,
    IWriteDbRepository<InventoryAuditTable> writeDbRepository) : IInventoryAuditRepository
{
    public async Task CreateAsync(InventoryAuditDto dto, CancellationToken cancellationToken = default)
    {
        await writeDbRepository.AddAsync(dto.ToTable(), cancellationToken);
    }

    public async Task<List<InventoryAuditDto>> GetAsync(GetInventoryAuditQuery q, CancellationToken cancellationToken = default)
    {
        var data = await readDbRepository.WhereAsync(i => i.ItemId == q.ItemId && i.UomId == q.UomId && i.WarehouseId == q.WarehouseId, cancellationToken);
        return data.Select(i => i.ToDto()).ToList();
    }
}
