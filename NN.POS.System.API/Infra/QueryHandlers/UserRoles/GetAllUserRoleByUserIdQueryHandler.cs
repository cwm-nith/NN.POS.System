using MediatR;
using NN.POS.System.API.App.Queries.UserRoles;
using NN.POS.System.API.Core.IRepositories.Roles;
using NN.POS.System.Model.Dtos.Roles;

namespace NN.POS.System.API.Infra.QueryHandlers.UserRoles;

public class GetAllUserRoleByUserIdQueryHandler(IUserRoleRepository userRoleRepository) : IRequestHandler<GetAllUserRoleByUserIdQuery, List<UserRoleDto>>
{
    public async Task<List<UserRoleDto>> Handle(GetAllUserRoleByUserIdQuery request, CancellationToken cancellationToken)
    {
        return await userRoleRepository.GetAllUserRolesAsync(request.UserId, cancellationToken);
    }
}