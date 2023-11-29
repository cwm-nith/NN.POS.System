using MediatR;
using NN.POS.System.API.Core.Entities.Roles;
using NN.POS.System.API.Core.IRepositories.Roles;

namespace NN.POS.System.API.App.Commands.Roles.Handlers;

public class UpdateRoleManyCommandHandler(IRoleRepository roleRepository) : IRequestHandler<UpdateRoleManyCommand, bool>
{
    public async Task<bool> Handle(UpdateRoleManyCommand request, CancellationToken cancellationToken)
    {
        var roleEntities = request.Roles
            .Select(i => new RoleEntity
            {
                Id = i.Id,
                Name = i.Name ?? "",
                CreatedAt = i.CreatedAt,
                UpdatedAt = DateTime.UtcNow,

                Description = i.Description,
                DisplayName = i.DisplayName,
            }).ToList();
        return await roleRepository.UpdateRoleManyAsync(roleEntities, cancellationToken);
    }
}