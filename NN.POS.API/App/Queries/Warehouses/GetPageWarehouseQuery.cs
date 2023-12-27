using MediatR;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.Warehouses;

namespace NN.POS.API.App.Queries.Warehouses;

public class GetPageWarehouseQuery : PagedQuery, IRequest<PagedResult<WarehouseDto>>
{
    public string? Search { get; set; }
}