using MediatR;
using NN.POS.System.API.Core.Dtos.Roles;

namespace NN.POS.System.API.App.Commands.Roles;

public class UpdateRoleManyCommand : IRequest<bool>
{
    public List<UpdateRoleDto> Roles { get; set; }

    public UpdateRoleManyCommand(List<UpdateRoleDto> roles)
    {
        Roles = roles;
    }
}