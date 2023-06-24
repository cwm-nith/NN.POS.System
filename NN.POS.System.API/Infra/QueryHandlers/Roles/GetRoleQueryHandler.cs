using MediatR;
using NN.POS.System.API.App.Queries.Roles;
using NN.POS.System.API.Commons.Pagination;
using NN.POS.System.API.Core.Dtos.Roles;
using NN.POS.System.API.Core.IRepositories.Roles;
using NN.POS.System.API.Infra.Tables.Roles;

namespace NN.POS.System.API.Infra.QueryHandlers.Roles;

public class GetRoleQueryHandler : IRequestHandler<GetRoleQuery, PagedResult<RoleDto>>
{
    private readonly IRoleRepository _roleRepository;

    public GetRoleQueryHandler(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<PagedResult<RoleDto>> Handle(GetRoleQuery request, CancellationToken cancellationToken)
    {
        var roles = await _roleRepository.GetRolesAsync(i => true, request, cancellationToken);
        return roles.Map(i => i.ToDto());
    }
}