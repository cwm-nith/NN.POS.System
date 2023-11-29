using MediatR;
using NN.POS.API.Core.Exceptions.Roles;
using NN.POS.API.Core.IRepositories.Roles;
using NN.POS.API.Infra.Tables.Roles;
using NN.POS.Model.Dtos.Roles;

namespace NN.POS.API.App.Commands.Roles.Handlers;

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