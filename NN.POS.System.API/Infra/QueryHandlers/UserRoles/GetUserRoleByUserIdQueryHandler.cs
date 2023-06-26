using MediatR;
using NN.POS.System.API.App.Queries.UserRoles;
using NN.POS.System.API.Core.IRepositories.Roles;
using NN.POS.System.Model.Dtos.Roles;

namespace NN.POS.System.API.Infra.QueryHandlers.UserRoles;

public class GetUserRoleByUserIdQueryHandler : IRequestHandler<GetUserRoleByUserIdQuery, List<UserRoleDto>>
{
    private readonly IUserRoleRepository _userRoleRepository;

    public GetUserRoleByUserIdQueryHandler(IUserRoleRepository userRoleRepository)
    {
        _userRoleRepository = userRoleRepository;
    }

    public Task<List<UserRoleDto>> Handle(GetUserRoleByUserIdQuery request, CancellationToken cancellationToken)
    {
        return _userRoleRepository.GetUserRolesAsync(request.UserId, cancellationToken);
    }
}