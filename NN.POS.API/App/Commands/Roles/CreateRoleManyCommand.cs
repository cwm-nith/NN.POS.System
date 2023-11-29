using MediatR;
using NN.POS.Model.Dtos.Roles;

namespace NN.POS.API.App.Commands.Roles;

public class CreateRoleManyCommand : IRequest<bool>
{
    public List<CreateRoleDto> Roles { get; set; }

    public CreateRoleManyCommand(List<CreateRoleDto> roles)
    {
        Roles = roles;
    }
}