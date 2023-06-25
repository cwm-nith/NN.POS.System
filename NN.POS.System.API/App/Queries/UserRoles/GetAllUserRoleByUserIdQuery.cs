using MediatR;
using NN.POS.System.API.Core.Dtos.Roles;

namespace NN.POS.System.API.App.Queries.UserRoles;

public class GetAllUserRoleByUserIdQuery : IRequest<List<UserRoleDto>>
{
    public int UserId { get; set; }

    public GetAllUserRoleByUserIdQuery(int userId)
    {
        UserId = userId;
    }
}