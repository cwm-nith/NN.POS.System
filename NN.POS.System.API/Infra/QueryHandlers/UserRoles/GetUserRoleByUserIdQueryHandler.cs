using MediatR;
using NN.POS.System.API.App.Queries.UserRoles;
using NN.POS.System.API.Core.IRepositories.Roles;
using NN.POS.System.Model.Dtos.Roles;

namespace NN.POS.System.API.Infra.QueryHandlers.UserRoles;

public class GetUserRoleByUserIdQueryHandler(IUserRoleRepository userRoleRepository) : IRequestHandler<GetUserRoleByUserIdQuery, List<UserRoleDto>>
{
    public async Task<List<UserRoleDto>> Handle(GetUserRoleByUserIdQuery request, CancellationToken cancellationToken)
    {
        return await userRoleRepository.GetUserRolesAsync(request.UserId, cancellationToken);
    }
}