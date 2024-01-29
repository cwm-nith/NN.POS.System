using NN.POS.API.App.Queries.Inventories;
using NN.POS.Model.Dtos.Inventories;

namespace NN.POS.API.Core.IRepositories.Inventories;

public interface IInventoryAuditRepository : IRepository
{
    Task CreateAsync(InventoryAuditDto dto, CancellationToken cancellationToken = default);
    Task<List<InventoryAuditDto>> GetAsync(GetInventoryAuditQuery q, CancellationToken cancellationToken = default);
}
