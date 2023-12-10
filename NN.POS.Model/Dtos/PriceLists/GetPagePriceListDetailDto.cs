using NN.POS.Common.Pagination;

namespace NN.POS.Model.Dtos.PriceLists;

public class GetPagePriceListDetailDto :PagedQuery, IBaseDto
{
    public int PriceListId { get; set; }
    public string? Search { get; set; }
}