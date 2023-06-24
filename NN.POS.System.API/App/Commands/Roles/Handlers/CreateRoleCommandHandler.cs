using MediatR;
using NN.POS.System.API.Core.Dtos.Roles;
using NN.POS.System.API.Core.Entities.Roles;
using NN.POS.System.API.Core.IRepositories.Roles;
using NN.POS.System.API.Infra.Tables.Roles;

namespace NN.POS.System.API.App.Commands.Roles.Handlers;

public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, RoleDto>
{
    private readonly IRoleRepository _roleRepository;

    public CreateRoleCommandHandler(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<RoleDto> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        var roleEn = new RoleEntity(request.Name, DateTime.UtcNow, DateTime.UtcNow)
        {
            DisplayName = request.DisplayName,
            Description = request.Description,
        };
        var role = await _roleRepository.CreateRoleAsync(roleEn, cancellationToken);
        return role.ToDto();
    }
}