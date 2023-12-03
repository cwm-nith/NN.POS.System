using MediatR;
using NN.POS.Model.Dtos.BusinessPartners.CustomerGroups;

namespace NN.POS.API.App.Commands.BusinessPartners;

public class CreateCustomerGroupCommand : IRequest
{
    public CreateCustomerGroupDto Dto { get; set; } = new ();
}