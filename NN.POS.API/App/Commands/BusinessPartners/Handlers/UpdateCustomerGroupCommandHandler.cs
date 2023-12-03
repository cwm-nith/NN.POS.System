using MediatR;
using NN.POS.API.Core.IRepositories.BusinessPartners;

namespace NN.POS.API.App.Commands.BusinessPartners.Handlers;

public class UpdateCustomerGroupCommandHandler(ICustomerGroupRepository repository) : IRequestHandler<UpdateCustomerGroupCommand>
{
    public async Task Handle(UpdateCustomerGroupCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, cancellationToken);

        var r = request.Dto;
        entity.Name = r.Name ?? entity.Name;
        entity.Value = r.Value ?? entity.Value;

        await repository.UpdateAsync(entity, cancellationToken);
    }
}