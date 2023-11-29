using MediatR;
using NN.POS.Model.Dtos.Roles;

namespace NN.POS.API.App.Commands.Roles;

public class UpdateRoleCommand: IRequest<RoleDto>
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? DisplayName { get; set; }
    public string? Description { get; set; }
    public UpdateRoleCommand(int id, string? name)
    {
        Id = id;
        Name = name;
    }
}