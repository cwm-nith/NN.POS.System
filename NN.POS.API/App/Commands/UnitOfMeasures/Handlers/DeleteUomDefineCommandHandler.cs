using MediatR;
using NN.POS.API.Core.IRepositories.UnitOfMeasures;

namespace NN.POS.API.App.Commands.UnitOfMeasures.Handlers;

public class DeleteUomDefineCommandHandler(IUnitOfMeasureDefineRepository repository) : IRequestHandler<DeleteUomDefineCommand>
{
    public async Task Handle(DeleteUomDefineCommand request, CancellationToken cancellationToken)
    {
        await repository.DeleteAsync(request.Id, cancellationToken);
    }
}