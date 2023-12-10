using MediatR;
using NN.POS.API.Core.IRepositories.UnitOfMeasures;

namespace NN.POS.API.App.Commands.UnitOfMeasures.Handlers;

public class DeleteUomGroupCommandHandler(IUnitOfMeasureGroupRepository repository) : IRequestHandler<DeleteUomGroupCommand>
{
    public async Task Handle(DeleteUomGroupCommand request, CancellationToken cancellationToken)
    {
        await repository.DeleteAsync(request.Id, cancellationToken);
    }
}