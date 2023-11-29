using MediatR;
using NN.POS.System.API.App.Queries.Roles;
using NN.POS.System.API.Core.IRepositories.Roles;
using NN.POS.System.API.Infra.Tables.Roles;
using NN.POS.System.Common.Pagination;
using NN.POS.System.Model.Dtos.Roles;

namespace NN.POS.System.API.Infra.QueryHandlers.Roles;

public class GetRoleQueryHandler(IRoleRepository roleRepository) : IRequestHandler<GetRoleQuery, PagedResult<RoleDto>>
{
    public async Task<PagedResult<RoleDto>> Handle(GetRoleQuery request, CancellationToken cancellationToken)
    {
        var roles = await roleRepository.GetRolesAsync(i => true, request, cancellationToken);
        return roles.Map(i => i.ToDto());
    }
}