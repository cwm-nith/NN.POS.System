using MediatR;
using NN.POS.API.App.Queries.Warehouses;
using NN.POS.API.Core.IRepositories.Warehouses;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.Warehouses;

namespace NN.POS.API.Infra.QueryHandlers.Warehouses;

public class GetPageWarehouseQueryHandler(IWarehouseRepository repository) : IRequestHandler<GetPageWarehouseQuery, PagedResult<WarehouseDto>>
{
    public async Task<PagedResult<WarehouseDto>> Handle(GetPageWarehouseQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetPageAsync(request, cancellationToken);
    }
}