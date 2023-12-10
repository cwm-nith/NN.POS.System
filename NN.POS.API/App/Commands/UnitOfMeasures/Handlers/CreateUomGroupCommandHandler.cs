using MediatR;
using NN.POS.API.Core.IRepositories.UnitOfMeasures;
using NN.POS.Model.Dtos.UnitOfMeasures;

namespace NN.POS.API.App.Commands.UnitOfMeasures.Handlers;

public class CreateUomGroupCommandHandler(IUnitOfMeasureGroupRepository repository) : IRequestHandler<CreateUomGroupCommand>
{
    public async Task Handle(CreateUomGroupCommand request, CancellationToken cancellationToken)
    {
        await repository.CreateAsync(new UnitOfMeasureGroupDto
        {
            CreatedAt = DateTime.UtcNow,
            Id = 0,
            IsDeleted = false,
            Name = request.Name
        }, cancellationToken);
    }
}