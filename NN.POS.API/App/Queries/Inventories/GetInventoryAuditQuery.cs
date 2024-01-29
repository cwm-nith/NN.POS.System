using MediatR;
using NN.POS.Model.Dtos.Inventories;

namespace NN.POS.API.App.Queries.Inventories;

public class GetInventoryAuditQuery : IRequest<List<InventoryAuditDto>>
{
    public int ItemId { get; set; }
    public int UomId { get; set; }
    public int WarehouseId { get; set; }
}
