using MediatR;
using NN.POS.System.API.Core.Dtos.Roles;
using NN.POS.System.API.Core.Exceptions.Roles;
using NN.POS.System.API.Core.IRepositories.Roles;
using NN.POS.System.API.Infra.Tables.Roles;

namespace NN.POS.System.API.App.Commands.Roles.Handlers;

public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, RoleDto>
{
    private readonly IRoleRepository _roleRepository;

    public UpdateRoleCommandHandler(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<RoleDto> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
    {
        var role = await _roleRepository.GetRoleByIdAsync(request.Id, cancellationToken) ??
                   throw new RoleNotFoundException(request.Id);
        role.Name = request.Name ?? role.Name;
        role.DisplayName = request.DisplayName ?? role.DisplayName;
        role.Description = request.Description ?? role.Description;
        var updatedRole = await _roleRepository.UpdateRoleAsync(role, cancellationToken);
        return updatedRole.ToDto();
    }
}