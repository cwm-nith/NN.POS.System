using NN.POS.Common.Pagination;

namespace NN.POS.Model.Dtos.BusinessPartners.CustomerGroups;

public class GetCustomerGroupDto : PagedQuery
{
    public string? Search { get; set; }
}