using MediatR;
using NN.POS.API.Core.Entities.Roles;
using NN.POS.API.Core.IRepositories.Roles;

namespace NN.POS.API.App.Commands.Roles.Handlers;

public class CreateRoleManyCommandHandler(IRoleRepository roleRepository) : IRequestHandler<CreateRoleManyCommand, bool>
{
    public Task<bool> Handle(CreateRoleManyCommand request, CancellationToken cancellationToken)
    {
        var roleEntities = request.Roles.Select(i =>
            new RoleEntity
            {
                Name = i.Name, 
                CreatedAt = DateTime.UtcNow, 
                UpdatedAt = DateTime.UtcNow,

                Description = i.Description,
                DisplayName = i.DisplayName
            }).ToList();
        return roleRepository.CreateRoleManyAsync(roleEntities, cancellationToken);
    }
}