using NN.POS.Common.Pagination;

namespace NN.POS.Model.Dtos.PriceLists;

public class GetPagePriceListDetailDto :PagedQuery, IBaseDto
{
    public string? Search { get; set; }
}