using MediatR;

namespace NN.POS.API.App.Commands.BusinessPartners;

public class DeleteCustomerGroupCommand : IRequest
{
    public int Id { get; set; }
}