using MediatR;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.BusinessPartners.CustomerGroups;

namespace NN.POS.API.App.Queries.BusinessPartners.CustomerGroups
{
    public class GetCustomerGroupsQuery : PagedQuery, IRequest<PagedResult<CustomerGroupDto>>
    {
        public string? Search { get; set; }
    }
}
