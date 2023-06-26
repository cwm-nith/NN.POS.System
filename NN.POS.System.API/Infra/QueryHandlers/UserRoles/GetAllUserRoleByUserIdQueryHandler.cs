using MediatR;
using NN.POS.System.API.App.Queries.UserRoles;
using NN.POS.System.API.Core.IRepositories.Roles;
using NN.POS.System.Model.Dtos.Roles;

namespace NN.POS.System.API.Infra.QueryHandlers.UserRoles;

public class GetAllUserRoleByUserIdQueryHandler : IRequestHandler<GetAllUserRoleByUserIdQuery, List<UserRoleDto>>
{
    private readonly IUserRoleRepository _userRoleRepository;

    public GetAllUserRoleByUserIdQueryHandler(IUserRoleRepository userRoleRepository)
    {
        _userRoleRepository = userRoleRepository;
    }

    public Task<List<UserRoleDto>> Handle(GetAllUserRoleByUserIdQuery request, CancellationToken cancellationToken)
    {
        return _userRoleRepository.GetAllUserRolesAsync(request.UserId, cancellationToken);
    }
}