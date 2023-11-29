using MediatR;
using NN.POS.Model.Dtos.Roles;

namespace NN.POS.API.App.Queries.UserRoles;

public class GetAllUserRoleByUserIdQuery : IRequest<List<UserRoleDto>>
{
    public int UserId { get; set; }

    public GetAllUserRoleByUserIdQuery(int userId)
    {
        UserId = userId;
    }
}