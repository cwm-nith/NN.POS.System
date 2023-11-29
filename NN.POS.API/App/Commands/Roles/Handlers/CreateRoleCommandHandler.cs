using MediatR;
using NN.POS.API.Core.Entities.Roles;
using NN.POS.API.Core.IRepositories.Roles;
using NN.POS.API.Infra.Tables.Roles;
using NN.POS.Model.Dtos.Roles;

namespace NN.POS.API.App.Commands.Roles.Handlers;

public class CreateRoleCommandHandler(IRoleRepository roleRepository) : IRequestHandler<CreateRoleCommand, RoleDto>
{
    public async Task<RoleDto> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        var roleEn = new RoleEntity
        {
            Name = request.Name,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,

            DisplayName = request.DisplayName,
            Description = request.Description
        };
        var role = await roleRepository.CreateRoleAsync(roleEn, cancellationToken);
        return role.ToDto();
    }
}