using NN.POS.Common.Pagination;

namespace NN.POS.Model.Dtos.Company;

public class GetCompanyPageDto :PagedQuery, IBaseDto
{
    public string? Search { get; set; }
}