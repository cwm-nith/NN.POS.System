using NN.POS.API.Core.IRepositories.Warehouses;
using NN.POS.API.Infra.Tables;
using NN.POS.API.Infra.Tables.Warehouses;
using NN.POS.Model.Dtos.Warehouses;

namespace NN.POS.API.Infra.Repositories.Warehouses;

public class WarehouseSummaryRepository(
    IReadDbRepository<WarehouseSummaryTable> readDbRepository,
    IWriteDbRepository<WarehouseSummaryTable> writeDbRepository) : IWarehouseSummaryRepository
{
    public async Task CreateAsync(WarehouseSummaryDto ws, CancellationToken cancellationToken = default)
    {
        await writeDbRepository.AddAsync(ws.ToTable(), cancellationToken);
    }

    public async Task<WarehouseSummaryDto?> GetAsync(int whId, int itemId, CancellationToken cancellationToken = default)
    {
        var ws = await readDbRepository.FirstOrDefaultAsync(i => i.WarehouseId == whId && i.ItemId == itemId,
            cancellationToken);
        return ws?.ToDto();
    }

    public async Task<List<WarehouseSummaryDto>> GetByWarehouseIdAsync(int whId, CancellationToken cancellationToken = default)
    {
        var ws = await readDbRepository.WhereAsync(i => i.WarehouseId == whId, cancellationToken);
        return ws.Select(i => i.ToDto()).ToList();
    }
}