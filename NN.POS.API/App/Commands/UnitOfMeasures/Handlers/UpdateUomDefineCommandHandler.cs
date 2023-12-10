using MediatR;
using NN.POS.API.Core.IRepositories.UnitOfMeasures;

namespace NN.POS.API.App.Commands.UnitOfMeasures.Handlers;

public class UpdateUomDefineCommandHandler(IUnitOfMeasureDefineRepository repository) : IRequestHandler<UpdateUomDefineCommand>
{
    public async Task Handle(UpdateUomDefineCommand request, CancellationToken cancellationToken)
    {
        await repository.UpdateAsync(request.Dto, request.Id, cancellationToken);
    }
}