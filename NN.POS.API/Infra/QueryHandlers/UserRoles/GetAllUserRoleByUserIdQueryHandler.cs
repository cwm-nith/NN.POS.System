using MediatR;
using NN.POS.API.App.Queries.UserRoles;
using NN.POS.API.Core.IRepositories.Roles;
using NN.POS.Model.Dtos.Roles;

namespace NN.POS.API.Infra.QueryHandlers.UserRoles;

public class GetAllUserRoleByUserIdQueryHandler(IUserRoleRepository userRoleRepository) : IRequestHandler<GetAllUserRoleByUserIdQuery, List<UserRoleDto>>
{
    public async Task<List<UserRoleDto>> Handle(GetAllUserRoleByUserIdQuery request, CancellationToken cancellationToken)
    {
        return await userRoleRepository.GetAllUserRolesAsync(request.UserId, cancellationToken);
    }
}