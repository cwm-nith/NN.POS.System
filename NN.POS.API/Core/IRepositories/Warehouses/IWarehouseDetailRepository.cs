using NN.POS.API.Infra.Tables.Warehouses;
using NN.POS.Model.Dtos.Warehouses;
using System.Linq.Expressions;

namespace NN.POS.API.Core.IRepositories.Warehouses;

public interface IWarehouseDetailRepository : IRepository
{
    Task CreateAsync(WarehouseDetailDto wd, CancellationToken cancellationToken = default);
    Task<WarehouseDetailDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<WarehouseDetailDto?> GetAsync(Expression<Func<WarehouseDetailTable, bool>> expression, CancellationToken cancellationToken = default);
    Task<List<WarehouseDetailDto>> GetByWarehouseIdAsync(int whId, CancellationToken cancellationToken = default);
}