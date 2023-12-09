using MediatR;
using NN.POS.API.Core.IRepositories.UnitOfMeasures;

namespace NN.POS.API.App.Commands.UnitOfMeasures.Handlers;

public class UpdateUomCommandHandler(IUnitOfMeasureRepository repository) : IRequestHandler<UpdateUomCommand>
{
    public async Task Handle(UpdateUomCommand request, CancellationToken cancellationToken)
    {
        await repository.UpdateAsync(request.Name, request.Id, cancellationToken);
    }
}