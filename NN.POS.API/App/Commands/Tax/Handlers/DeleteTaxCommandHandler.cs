using MediatR;
using NN.POS.API.Core.IRepositories.Tax;

namespace NN.POS.API.App.Commands.Tax.Handlers;

public class DeleteTaxCommandHandler(ITaxRepository repository) : IRequestHandler<DeleteTaxCommand>
{
    public async Task Handle(DeleteTaxCommand request, CancellationToken cancellationToken)
    {
        await repository.DeleteAsync(request.Id, cancellationToken);
    }
}
