using MediatR;
using NN.POS.System.API.Core.Exceptions.Roles;
using NN.POS.System.API.Core.IRepositories.Roles;
using NN.POS.System.API.Infra.Tables.Roles;
using NN.POS.System.Model.Dtos.Roles;

namespace NN.POS.System.API.App.Commands.Roles.Handlers;

public class UpdateRoleCommandHandler(IRoleRepository roleRepository) : IRequestHandler<UpdateRoleCommand, RoleDto>
{
    public async Task<RoleDto> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
    {
        var role = await roleRepository.GetRoleByIdAsync(request.Id, cancellationToken) ??
                   throw new RoleNotFoundException(request.Id);
        role.Name = request.Name ?? role.Name;
        role.DisplayName = request.DisplayName ?? role.DisplayName;
        role.Description = request.Description ?? role.Description;
        var updatedRole = await roleRepository.UpdateRoleAsync(role, cancellationToken);
        return updatedRole.ToDto();
    }
}