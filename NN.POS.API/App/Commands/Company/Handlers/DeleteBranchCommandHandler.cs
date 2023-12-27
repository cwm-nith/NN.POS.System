using MediatR;
using NN.POS.API.Core.IRepositories.Currencies;

namespace NN.POS.API.App.Commands.Company.Handlers;

public class DeleteBranchCommandHandler(IBranchRepository repository) : IRequestHandler<DeleteBranchCommand>
{
    public async Task Handle(DeleteBranchCommand request, CancellationToken cancellationToken)
    {
        await repository.DeleteAsync(request.Id, cancellationToken);
    }
}