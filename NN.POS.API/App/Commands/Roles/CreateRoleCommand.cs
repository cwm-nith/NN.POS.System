using MediatR;
using NN.POS.Model.Dtos.Roles;

namespace NN.POS.API.App.Commands.Roles;

public class CreateRoleCommand : IRequest<RoleDto>
{
    public string Name { get; set; }
    public string? DisplayName { get; set; }
    public string? Description { get; set; }

    public CreateRoleCommand(string name)
    {
        Name = name;
    }
}