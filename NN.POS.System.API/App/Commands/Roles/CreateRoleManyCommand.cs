using MediatR;
using NN.POS.System.API.Core.Dtos.Roles;

namespace NN.POS.System.API.App.Commands.Roles;

public class CreateRoleManyCommand : IRequest<bool>
{
    public List<CreateRoleDto> Roles { get; set; }

    public CreateRoleManyCommand(List<CreateRoleDto> roles)
    {
        Roles = roles;
    }
}