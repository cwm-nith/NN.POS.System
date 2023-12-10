using NN.POS.Common.Pagination;

namespace NN.POS.Model.Dtos.PriceLists;

public class GetPagePriceListDto : PagedQuery
{
    public string? Search { get; set; }
}