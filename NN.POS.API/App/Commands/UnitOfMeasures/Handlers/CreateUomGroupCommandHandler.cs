using MediatR;

namespace NN.POS.API.App.Commands.UnitOfMeasures.Handlers;

public class CreateUomGroupCommandHandler : IRequestHandler<CreateUomGroupCommand>
{
    public async Task Handle(CreateUomGroupCommand request, CancellationToken cancellationToken)
    {
        
    }
}