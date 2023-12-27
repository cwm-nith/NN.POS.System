using MediatR;
using NN.POS.Model.Dtos.Warehouses;

namespace NN.POS.API.App.Queries.Warehouses;

public class GetWarehouseByIdQuery(int id) : IRequest<WarehouseDto>
{
    public int Id => id;
}