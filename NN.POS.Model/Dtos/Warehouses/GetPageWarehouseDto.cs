using NN.POS.Common.Pagination;

namespace NN.POS.Model.Dtos.Warehouses;

public class GetPageWarehouseDto : PagedQuery, IBaseDto
{
    public string? Search { get; set; }
}