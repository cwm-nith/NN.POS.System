using MediatR;
using NN.POS.API.Core.IRepositories.BusinessPartners;

namespace NN.POS.API.App.Commands.BusinessPartners.Handlers;

public class DeleteCustomerGroupCommandHandler(ICustomerGroupRepository repository) : IRequestHandler<DeleteCustomerGroupCommand>
{
    public async Task Handle(DeleteCustomerGroupCommand request, CancellationToken cancellationToken)
    {
        await repository.DeleteAsync(request.Id, cancellationToken);
    }
}