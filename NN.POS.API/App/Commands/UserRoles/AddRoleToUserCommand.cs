using MediatR;

namespace NN.POS.API.App.Commands.UserRoles;

public class AddRoleToUserCommand : IRequest<bool>
{
    public int UserId { get; set; }
    public int RoleId { get; set; }

    public AddRoleToUserCommand(int userId, int roleId)
    {
        UserId = userId;
        RoleId = roleId;
    }
}