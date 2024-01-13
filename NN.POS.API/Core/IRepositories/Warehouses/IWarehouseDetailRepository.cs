using NN.POS.Model.Dtos.Warehouses;

namespace NN.POS.API.Core.IRepositories.Warehouses;

public interface IWarehouseDetailRepository : IRepository
{
    Task CreateAsync(WarehouseDetailDto wd, CancellationToken cancellationToken = default);
    Task<WarehouseDetailDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<List<WarehouseDetailDto>> GetByWarehouseIdAsync(int whId, CancellationToken cancellationToken = default);
}