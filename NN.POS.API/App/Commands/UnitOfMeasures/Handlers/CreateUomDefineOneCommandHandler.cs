using MediatR;
using NN.POS.API.Core.IRepositories.UnitOfMeasures;
using NN.POS.Model.Dtos.UnitOfMeasures;

namespace NN.POS.API.App.Commands.UnitOfMeasures.Handlers;

public class CreateUomDefineOneCommandHandler(IUnitOfMeasureDefineRepository repository) : IRequestHandler<CreateUomDefineOneCommand>
{
    public async Task Handle(CreateUomDefineOneCommand request, CancellationToken cancellationToken)
    {
        var r = request.Dto;
        await repository.CreateAsync(new UnitOfMeasureDefineDto
        {
            AltQty = r.AltQty,
            AltUomId = r.AltUomId,
            BaseQty = r.BaseQty,
            BaseUomId = r.BaseUomId,
            CreatedAt = DateTime.UtcNow,
            Factor = r.Factor,
            GroupUomId = r.GroupUomId,
            Id = r.Id,
            IsDeleted = false
        }, cancellationToken);
    }
}