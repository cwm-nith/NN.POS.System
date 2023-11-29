using MediatR;
using NN.POS.System.API.Core.Entities.Roles;
using NN.POS.System.API.Core.IRepositories.Roles;

namespace NN.POS.System.API.App.Commands.Roles.Handlers;

public class UpdateRoleManyCommandHandler(IRoleRepository roleRepository) : IRequestHandler<UpdateRoleManyCommand, bool>
{
    public async Task<bool> Handle(UpdateRoleManyCommand request, CancellationToken cancellationToken)
    {
        var roleEntities = request.Roles
            .Select(i => new RoleEntity(i.Name ?? "", i.CreatedAt, DateTime.UtcNow)
            {
                Id = i.Id,
                Description = i.Description,
                DisplayName = i.DisplayName,
            }).ToList();
        return await roleRepository.UpdateRoleManyAsync(roleEntities, cancellationToken);
    }
}