using MediatR;
using NN.POS.API.Core.Entities.BusinessPartners.CustomerGroups;
using NN.POS.API.Core.IRepositories.BusinessPartners;

namespace NN.POS.API.App.Commands.BusinessPartners.Handlers;

public class CreateCustomerGroupCommandHandler(ICustomerGroupRepository repository) : IRequestHandler<CreateCustomerGroupCommand>
{
    public async Task Handle(CreateCustomerGroupCommand request, CancellationToken cancellationToken)
    {
        var entity = new CustomerGroupEntity
        {
            CreatedAt = DateTime.UtcNow,
            Id = 0,
            Name = request.Dto.Name,
            UpdatedAt = DateTime.UtcNow,
            Value = request.Dto.Value
        };

        await repository.AddAsync(entity, cancellationToken);
    }
}