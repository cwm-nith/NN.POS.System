using MediatR;
using NN.POS.API.Core.IRepositories.UnitOfMeasures;

namespace NN.POS.API.App.Commands.UnitOfMeasures.Handlers;

public class UpdateUomGroupCommandHandler(IUnitOfMeasureGroupRepository repository) : IRequestHandler<UpdateUomGroupCommand>
{
    public async Task Handle(UpdateUomGroupCommand request, CancellationToken cancellationToken)
    {
        await repository.UpdateAsync(request.Name, request.Id, cancellationToken);
    }
}