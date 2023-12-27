using NN.POS.API.App.Queries.Warehouses;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.Warehouses;

namespace NN.POS.API.Core.IRepositories.Warehouses;

public interface IWarehouseRepository : IRepository
{
    Task CreateAsync(WarehouseDto ws, CancellationToken cancellationToken = default);
    Task UpdateAsync(WarehouseDto ws, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    Task<WarehouseDto> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<PagedResult<WarehouseDto>> GetPageAsync(GetPageWarehouseQuery query, CancellationToken cancellationToken = default);
}