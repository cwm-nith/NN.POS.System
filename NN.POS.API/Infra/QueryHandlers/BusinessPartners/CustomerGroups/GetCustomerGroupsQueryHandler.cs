using MediatR;
using NN.POS.API.App.Queries.BusinessPartners.CustomerGroups;
using NN.POS.API.Core.IRepositories.BusinessPartners;
using NN.POS.API.Infra.Tables.BusinessPartners;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.BusinessPartners.CustomerGroups;

namespace NN.POS.API.Infra.QueryHandlers.BusinessPartners.CustomerGroups;

public class GetCustomerGroupsQueryHandler(ICustomerGroupRepository repository) : IRequestHandler<GetCustomerGroupsQuery, PagedResult<CustomerGroupDto>>
{
    public async Task<PagedResult<CustomerGroupDto>> Handle(GetCustomerGroupsQuery request, CancellationToken cancellationToken)
    {
        var data = await repository.GetAsync(request, cancellationToken);
        return data.Map(i => i.ToDto());
    }
}