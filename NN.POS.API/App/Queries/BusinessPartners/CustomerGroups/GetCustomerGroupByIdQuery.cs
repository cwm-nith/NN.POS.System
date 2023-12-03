using MediatR;
using NN.POS.Model.Dtos.BusinessPartners.CustomerGroups;

namespace NN.POS.API.App.Queries.BusinessPartners.CustomerGroups;

public class GetCustomerGroupByIdQuery : IRequest<CustomerGroupDto>
{
    public int Id { get; set; }
}