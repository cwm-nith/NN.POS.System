using MediatR;
using NN.POS.API.App.Queries.BusinessPartners.CustomerGroups;
using NN.POS.API.Core.IRepositories.BusinessPartners;
using NN.POS.API.Infra.Tables.BusinessPartners;
using NN.POS.Model.Dtos.BusinessPartners.CustomerGroups;

namespace NN.POS.API.Infra.QueryHandlers.BusinessPartners.CustomerGroups;

public class GetCustomerGroupByIdQueryHandler(ICustomerGroupRepository repository) : IRequestHandler<GetCustomerGroupByIdQuery, CustomerGroupDto>
{
    public async Task<CustomerGroupDto> Handle(GetCustomerGroupByIdQuery request, CancellationToken cancellationToken)
    {
        var data = await repository.GetByIdAsync(request.Id, cancellationToken);
        return data.ToDto();
    }
}