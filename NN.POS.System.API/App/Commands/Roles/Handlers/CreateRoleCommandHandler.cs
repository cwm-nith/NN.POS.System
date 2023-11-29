using MediatR;
using NN.POS.System.API.Core.Entities.Roles;
using NN.POS.System.API.Core.IRepositories.Roles;
using NN.POS.System.API.Infra.Tables.Roles;
using NN.POS.System.Model.Dtos.Roles;

namespace NN.POS.System.API.App.Commands.Roles.Handlers;

public class CreateRoleCommandHandler(IRoleRepository roleRepository) : IRequestHandler<CreateRoleCommand, RoleDto>
{
    public async Task<RoleDto> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        var roleEn = new RoleEntity(request.Name, DateTime.UtcNow, DateTime.UtcNow)
        {
            DisplayName = request.DisplayName,
            Description = request.Description,
        };
        var role = await roleRepository.CreateRoleAsync(roleEn, cancellationToken);
        return role.ToDto();
    }
}