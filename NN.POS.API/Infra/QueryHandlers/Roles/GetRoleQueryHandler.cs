using MediatR;
using NN.POS.API.App.Queries.Roles;
using NN.POS.API.Core.IRepositories.Roles;
using NN.POS.API.Infra.Tables.Roles;
using NN.POS.Common.Pagination;
using NN.POS.Model.Dtos.Roles;

namespace NN.POS.API.Infra.QueryHandlers.Roles;

public class GetRoleQueryHandler(IRoleRepository roleRepository) : IRequestHandler<GetRoleQuery, PagedResult<RoleDto>>
{
    public async Task<PagedResult<RoleDto>> Handle(GetRoleQuery request, CancellationToken cancellationToken)
    {
        var roles = await roleRepository.GetRolesAsync(i => true, request, cancellationToken);
        return roles.Map(i => i.ToDto());
    }
}