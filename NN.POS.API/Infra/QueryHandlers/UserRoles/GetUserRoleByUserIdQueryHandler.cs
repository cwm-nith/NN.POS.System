using MediatR;
using NN.POS.API.App.Queries.UserRoles;
using NN.POS.API.Core.IRepositories.Roles;
using NN.POS.Model.Dtos.Roles;

namespace NN.POS.API.Infra.QueryHandlers.UserRoles;

public class GetUserRoleByUserIdQueryHandler(IUserRoleRepository userRoleRepository) : IRequestHandler<GetUserRoleByUserIdQuery, List<UserRoleDto>>
{
    public async Task<List<UserRoleDto>> Handle(GetUserRoleByUserIdQuery request, CancellationToken cancellationToken)
    {
        return await userRoleRepository.GetUserRolesAsync(request.UserId, cancellationToken);
    }
}