using System.Linq.Expressions;
using NN.POS.System.API.Core.Entities.Roles;
using NN.POS.System.API.Core.Exceptions.Roles;
using NN.POS.System.API.Core.IRepositories.Roles;
using NN.POS.System.API.Infra.Tables;
using NN.POS.System.API.Infra.Tables.Roles;
using NN.POS.System.Common.Pagination;

namespace NN.POS.System.API.Infra.Repositories.Roles;

public class RoleRepository : IRoleRepository
{
    private readonly IWriteDbRepository<RoleTable> _writeDbRepository;
    private readonly IReadDbRepository<RoleTable> _readDbRepository;
    private readonly ILogger<RoleRepository> _logger;
    public RoleRepository(IWriteDbRepository<RoleTable> writeDbRepository,
        IReadDbRepository<RoleTable> readDbRepository, ILogger<RoleRepository> logger)
    {
        _writeDbRepository = writeDbRepository;
        _readDbRepository = readDbRepository;
        _logger = logger;
    }

    public async Task<RoleEntity?> GetRoleByIdAsync(int id, CancellationToken cancellation = default)
    {
        var role = await _readDbRepository.FirstOrDefaultAsync(i => i.Id == id, cancellation);
        return role?.ToEntity();
    }

    public async Task<RoleEntity?> GetRoleByNameAsync(string name, CancellationToken cancellation = default)
    {
        var role = await _readDbRepository.FirstOrDefaultAsync(i => i.Name == name, cancellation);
        return role?.ToEntity();
    }

    public async Task<PagedResult<RoleEntity>> GetRolesAsync(Expression<Func<RoleTable, bool>> predicate,
        PagedQuery query, CancellationToken cancellation = default)
    {
        var roles = await _readDbRepository.BrowseAsync(predicate, query, cancellation);
        var data = roles.Map(i => i.ToEntity());
        return data;
    }

    public Task<bool> IsRoleExistedAsync(int id, CancellationToken cancellation = default)
    {
        return _readDbRepository.ExistsAsync(i => i.Id == id, cancellation);
    }

    public Task<bool> IsRoleExistedAsync(string name, CancellationToken cancellation = default)
    {
        return _readDbRepository.ExistsAsync(i => i.Name == name, cancellation);
    }

    public async Task<RoleEntity> CreateRoleAsync(RoleEntity role, CancellationToken cancellation = default)
    {
        var newRole = await _writeDbRepository.AddAsync(role.ToTable(), cancellation);
        return newRole.ToEntity();
    }

    public Task<bool> CreateRoleManyAsync(List<RoleEntity> roles, CancellationToken cancellation = default)
    {
        return _writeDbRepository.AddManyAsync(roles.Select(i => i.ToTable()).ToList(), cancellation);
    }

    public Task<bool> UpdateRoleManyAsync(List<RoleEntity> roles, CancellationToken cancellation = default)
    {
        return _writeDbRepository.UpdateManyAsync(roles.Select(i => i.ToTable()).ToList(), cancellation);
    }

    public async Task<RoleEntity> UpdateRoleAsync(RoleEntity role, CancellationToken cancellation = default)
    {
        await _writeDbRepository.UpdateAsync(role.ToTable(), cancellation);
        return role;
    }

    public async Task<bool> DeleteRoleAsync(int id, CancellationToken cancellation = default)
    {
        var num = await _writeDbRepository.DeleteAsync(id, cancellation);
        return num > 0;
    }

    public async Task<bool> DeleteRoleAsync(string name, CancellationToken cancellation = default)
    {
        var role = await GetRoleByNameAsync(name, cancellation) ?? throw new RoleNotFoundException(name);
        var num = await _writeDbRepository.DeleteAsync(role.Id, cancellation);
        return num > 0;
    }

    public Task<bool> IsHasRoleAsync(CancellationToken cancellation = default)
    {
        try
        {
            return _readDbRepository.ExistsAsync(i => true, cancellation);
        }
        catch (Exception e)
        {
            _logger.LogDebug(e.Message);
            return Task.FromResult(false);
        }
    }
}