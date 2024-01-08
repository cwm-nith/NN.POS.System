using NN.POS.API.Core.IRepositories.Warehouses;
using NN.POS.API.Infra.Tables;
using NN.POS.API.Infra.Tables.Warehouses;
using NN.POS.Model.Dtos.Warehouses;

namespace NN.POS.API.Infra.Repositories.Warehouses;

public class WarehouseDetailRepository(
    IReadDbRepository<WarehouseDetailTable> readDbRepository,
    IWriteDbRepository<WarehouseDetailTable> writeDbRepository) : IWarehouseDetailRepository
{
    public async Task CreateAsync(WarehouseDetailDto wd, CancellationToken cancellationToken = default)
    {
        await writeDbRepository.AddAsync(wd.ToTable(), cancellationToken);
    }

    public async Task<WarehouseDetailDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var wd = await readDbRepository.FirstOrDefaultAsync(i => i.Id == id, cancellationToken);
        return wd?.ToDto();
    }

    public async Task<List<WarehouseDetailDto>> GetByWarehouseIdAsync(int whId,
        CancellationToken cancellationToken = default)
    {
        var wd = await readDbRepository.WhereAsync(i => i.WarehouseId == whId, cancellationToken);
        return wd.Select(i => i.ToDto()).ToList();
    }
}