using System.Linq.Expressions;
using NN.POS.API.Core.Entities.Roles;
using NN.POS.API.Core.Exceptions.Roles;
using NN.POS.API.Core.IRepositories.Roles;
using NN.POS.API.Infra.Tables;
using NN.POS.API.Infra.Tables.Roles;
using NN.POS.Common.Pagination;

namespace NN.POS.API.Infra.Repositories.Roles;

public class RoleRepository(IWriteDbRepository<RoleTable> writeDbRepository,
    IReadDbRepository<RoleTable> readDbRepository, ILogger<RoleRepository> logger) : IRoleRepository
{
    public async Task<RoleEntity?> GetRoleByIdAsync(int id, CancellationToken cancellation = default)
    {
        var role = await readDbRepository.FirstOrDefaultAsync(i => i.Id == id, cancellation);
        return role?.ToEntity();
    }

    public async Task<RoleEntity?> GetRoleByNameAsync(string name, CancellationToken cancellation = default)
    {
        var role = await readDbRepository.FirstOrDefaultAsync(i => i.Name == name, cancellation);
        return role?.ToEntity();
    }

    public async Task<PagedResult<RoleEntity>> GetRolesAsync(Expression<Func<RoleTable, bool>> predicate,
        PagedQuery query, CancellationToken cancellation = default)
    {
        var roles = await readDbRepository.BrowseAsync(predicate, query, cancellation);
        var data = roles.Map(i => i.ToEntity());
        return data;
    }

    public async Task<bool> IsRoleExistedAsync(int id, CancellationToken cancellation = default)
    {
        return await readDbRepository.ExistsAsync(i => i.Id == id, cancellation);
    }

    public async Task<bool> IsRoleExistedAsync(string name, CancellationToken cancellation = default)
    {
        return await readDbRepository.ExistsAsync(i => i.Name == name, cancellation);
    }

    public async Task<RoleEntity> CreateRoleAsync(RoleEntity role, CancellationToken cancellation = default)
    {
        var newRole = await writeDbRepository.AddAsync(role.ToTable(), cancellation);
        return newRole.ToEntity();
    }

    public async Task<bool> CreateRoleManyAsync(List<RoleEntity> roles, CancellationToken cancellation = default)
    {
        return await writeDbRepository.AddManyAsync(roles.Select(i => i.ToTable()).ToList(), cancellation);
    }

    public async Task<bool> UpdateRoleManyAsync(List<RoleEntity> roles, CancellationToken cancellation = default)
    {
        return await writeDbRepository.UpdateManyAsync(roles.Select(i => i.ToTable()).ToList(), cancellation);
    }

    public async Task<RoleEntity> UpdateRoleAsync(RoleEntity role, CancellationToken cancellation = default)
    {
        await writeDbRepository.UpdateAsync(role.ToTable(), cancellation);
        return role;
    }

    public async Task<bool> DeleteRoleAsync(int id, CancellationToken cancellation = default)
    {
        var num = await writeDbRepository.DeleteAsync(id, cancellation);
        return num > 0;
    }

    public async Task<bool> DeleteRoleAsync(string name, CancellationToken cancellation = default)
    {
        var role = await GetRoleByNameAsync(name, cancellation) ?? throw new RoleNotFoundException(name);
        var num = await writeDbRepository.DeleteAsync(role.Id, cancellation);
        return num > 0;
    }

    public async Task<bool> IsHasRoleAsync(CancellationToken cancellation = default)
    {
        try
        {
            return await readDbRepository.ExistsAsync(i => true, cancellation);
        }
        catch (Exception e)
        {
            logger.LogDebug("{message}", e.Message);
            return await Task.FromResult(false);
        }
    }
}