using MediatR;
using NN.POS.API.Core.IRepositories.UnitOfMeasures;
using NN.POS.Model.Dtos.UnitOfMeasures;

namespace NN.POS.API.App.Commands.UnitOfMeasures.Handlers;

public class CreateUomDefineCommandHandler(IUnitOfMeasureDefineRepository repository) : IRequestHandler<CreateUomDefineCommand>
{
    public async Task Handle(CreateUomDefineCommand request, CancellationToken cancellationToken)
    {
        var req = request.Dto;

        await repository.CreateManyAsync(req.Select(r => new UnitOfMeasureDefineDto
        {
            AltQty = r.AltQty,
            AltUomId = r.AltUomId,
            BaseQty = r.BaseQty,
            BaseUomId = r.BaseUomId,
            CreatedAt = DateTime.UtcNow,
            Factor = r.Factor,
            GroupUomId = r.GroupUomId,
            Id = 0,
            IsDeleted = false
        }).ToList(), cancellationToken);
    }
}