using MediatR;
using NN.POS.Model.Dtos.BusinessPartners.CustomerGroups;

namespace NN.POS.API.App.Commands.BusinessPartners;

public class UpdateCustomerGroupCommand : IRequest
{
    public int Id { get; set; }
    public UpdateCustomerGroupDto Dto { get; set; } = new();
}