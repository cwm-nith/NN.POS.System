using MediatR;
using NN.POS.System.API.Core.Entities.Roles;
using NN.POS.System.API.Core.IRepositories.Roles;

namespace NN.POS.System.API.App.Commands.Roles.Handlers;

public class CreateRoleManyCommandHandler(IRoleRepository roleRepository) : IRequestHandler<CreateRoleManyCommand, bool>
{
    public Task<bool> Handle(CreateRoleManyCommand request, CancellationToken cancellationToken)
    {
        var roleEntities = request.Roles.Select(i =>
            new RoleEntity(i.Name, DateTime.UtcNow, DateTime.UtcNow)
            {
                Description = i.Description,
                DisplayName = i.DisplayName
            }).ToList();
        return roleRepository.CreateRoleManyAsync(roleEntities, cancellationToken);
    }
}