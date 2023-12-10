using NN.POS.Common.Pagination;

namespace NN.POS.Model.Dtos.UnitOfMeasures;

public class GetPageUomDto : PagedQuery
{
    public string? Search { get; set; }
}