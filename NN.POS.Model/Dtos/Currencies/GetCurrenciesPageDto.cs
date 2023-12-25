using NN.POS.Common.Pagination;

namespace NN.POS.Model.Dtos.Currencies;

public class GetCurrenciesPageDto : PagedQuery, IBaseDto
{
    public string? Search { get; set; }
}