using MediatR;
using NN.POS.API.Core.IRepositories.UnitOfMeasures;

namespace NN.POS.API.App.Commands.UnitOfMeasures.Handlers;

public class DeleteUomCommandHandler(IUnitOfMeasureRepository repository) : IRequestHandler<DeleteUomCommand>
{
    public async Task Handle(DeleteUomCommand request, CancellationToken cancellationToken)
    {
        await repository.DeleteAsync(request.Id, cancellationToken);
    }
}