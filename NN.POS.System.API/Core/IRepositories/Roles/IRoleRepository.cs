using System.Linq.Expressions;
using NN.POS.System.API.Commons.Pagination;
using NN.POS.System.API.Core.Entities.Roles;
using NN.POS.System.API.Infra.Tables.Roles;

namespace NN.POS.System.API.Core.IRepositories.Roles;

public interface IRoleRepository
{
    Task<RoleEntity?> GetRoleByIdAsync(int id, CancellationToken cancellation = default);
    Task<RoleEntity?> GetRoleByNameAsync(string name, CancellationToken cancellation = default);
    Task<PagedResult<RoleEntity>> GetRolesAsync(Expression<Func<RoleTable, bool>> predicate, PagedQuery query,
        CancellationToken cancellation = default);
    Task<bool> IsRoleExistedAsync(int id, CancellationToken cancellation = default);
    Task<bool> IsRoleExistedAsync(string name, CancellationToken cancellation = default);

    Task<RoleEntity> CreateRoleAsync(RoleEntity role, CancellationToken cancellation = default);
    Task<bool> CreateRoleManyAsync(List<RoleEntity> roles, CancellationToken cancellation = default);
    Task<bool> UpdateRoleManyAsync(List<RoleEntity> roles, CancellationToken cancellation = default);
    Task<RoleEntity> UpdateRoleAsync(RoleEntity role, CancellationToken cancellation = default);
    Task<bool> DeleteRoleAsync(int id, CancellationToken cancellation = default);
    Task<bool> DeleteRoleAsync(string name, CancellationToken cancellation = default);
    Task<bool> IsHasRoleAsync(CancellationToken cancellation = default);
}