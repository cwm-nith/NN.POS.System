using MediatR;
using NN.POS.API.App.Queries.Warehouses;
using NN.POS.API.Core.IRepositories.Warehouses;
using NN.POS.Model.Dtos.Warehouses;

namespace NN.POS.API.Infra.QueryHandlers.Warehouses;

public class GetWarehouseByIdQueryHandler(IWarehouseRepository repository) : IRequestHandler<GetWarehouseByIdQuery, WarehouseDto>
{
    public async Task<WarehouseDto> Handle(GetWarehouseByIdQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetByIdAsync(request.Id, cancellationToken);
    }
}