using NN.POS.Model.Dtos.Warehouses;

namespace NN.POS.API.Core.IRepositories.Warehouses;

public interface IWarehouseSummaryRepository : IRepository
{
    Task CreateAsync(WarehouseSummaryDto ws, CancellationToken cancellationToken = default);
    Task<WarehouseSummaryDto?> GetAsync(int whId, int itemId, CancellationToken cancellationToken = default);
    Task<List<WarehouseSummaryDto>> GetByWarehouseIdAsync(int whId, CancellationToken cancellationToken = default);
}