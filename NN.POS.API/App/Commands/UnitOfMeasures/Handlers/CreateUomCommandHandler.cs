using MediatR;
using NN.POS.API.Core.IRepositories.UnitOfMeasures;
using NN.POS.Model.Dtos.UnitOfMeasures;

namespace NN.POS.API.App.Commands.UnitOfMeasures.Handlers;

public class CreateUomCommandHandler(IUnitOfMeasureRepository repository) : IRequestHandler<CreateUomCommand>
{
    public async Task Handle(CreateUomCommand request, CancellationToken cancellationToken)
    {
        await repository.CreateAsync(new UnitOfMeasureDto
        {
            CreatedAt = DateTime.UtcNow,
            Id = 0,
            IsDeleted = false,
            Name = request.Name,
        }, cancellationToken);
    }
}