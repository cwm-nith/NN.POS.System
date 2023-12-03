using MediatR;
using NN.POS.API.App.Queries.BusinessPartners.CustomerGroups;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.BusinessPartners.CustomerGroups;

namespace NN.POS.API.Infra.QueryHandlers.BusinessPartners.CustomerGroups;

public class GetCustomerGroupsQueryHandler : IRequestHandler<GetCustomerGroupsQuery, PagedResult<CustomerGroupDto>>
{
    public Task<PagedResult<CustomerGroupDto>> Handle(GetCustomerGroupsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}