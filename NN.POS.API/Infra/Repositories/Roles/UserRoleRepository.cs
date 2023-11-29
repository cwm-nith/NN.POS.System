using Microsoft.EntityFrameworkCore;
using NN.POS.API.Core.Exceptions.Roles;
using NN.POS.API.Core.Exceptions.UserRoles;
using NN.POS.API.Core.Exceptions.Users;
using NN.POS.API.Core.IRepositories.Roles;
using NN.POS.API.Infra.Tables;
using NN.POS.API.Infra.Tables.Roles;
using NN.POS.Model.Dtos.Roles;

namespace NN.POS.API.Infra.Repositories.Roles;

public class UserRoleRepository(
        IWriteDbRepository<UserRoleTable> writeDbRepository,
        IRoleRepository roleRepository,
        IReadDbRepository<UserRoleTable> readDbRepository
        )
    : IUserRoleRepository
{
    public async Task<bool> AddRoleToUserAsync(int userId, int roleId, CancellationToken cancellation = default)
    {
        var isRoleExisted = await roleRepository.IsRoleExistedAsync(roleId, cancellation);
        if (!isRoleExisted) throw new RoleNotFoundException(roleId);

        var isUserExisted = readDbRepository.Context.Users != null && await readDbRepository.Context.Users.AnyAsync(i => i.Id == userId, cancellation);
        if (!isUserExisted) throw new UserNotFoundException(userId);

        if (await UserRoleExistedAsync(userId, roleId, cancellation)) throw new UserRoleAlreadyExistedException(userId, roleId);

        var role = new UserRoleTable
        {
            Id = 0,
            UserId = userId, 
            RoleId = roleId
        };

        await writeDbRepository.AddAsync(role, cancellation);
        return true;
    }

    public async Task<bool> UserRoleExistedAsync(int userId, int roleId, CancellationToken cancellation = default)
    {
        return await readDbRepository.ExistsAsync(i => i.RoleId == roleId && i.UserId == userId, cancellation);
    }

    public async Task<bool> RemoveUserRoleAsync(int userId, int roleId, CancellationToken cancellation = default)
    {
        var isRoleExisted = await roleRepository.IsRoleExistedAsync(roleId, cancellation);
        if (!isRoleExisted) throw new RoleNotFoundException(roleId);

        var isUserExisted = readDbRepository.Context.Users != null && await readDbRepository.Context.Users.AnyAsync(i => i.Id == userId, cancellation);
        if (!isUserExisted) throw new UserNotFoundException(userId);

        if (!(await UserRoleExistedAsync(userId, roleId, cancellation))) throw new UserRoleNotExistedException(userId, roleId);
        var role = await readDbRepository.FirstOrDefaultAsync(i => i.UserId == userId && i.RoleId == roleId, cancellation) ?? throw new UserRoleNotFoundException();
        var num = await writeDbRepository.DeleteAsync(role.Id, cancellation);
        return num > 0;
    }

    public async Task<List<UserRoleDto>> GetUserRolesAsync(int userId, CancellationToken cancellation = default)
    {
        var context = readDbRepository.Context;
        var data = await (from userRole in context.UserRoles!
                          join role in context.Roles! on userRole.RoleId equals role.Id
                          where userRole.UserId == userId
                          select new UserRoleDto
                          {
                              Id = userRole.Id,
                              UserId = userId,
                              RoleId = role.Id,
                              Name = role.Name,
                              CreatedAt = role.CreatedAt,
                              UpdatedAt = role.UpdatedAt,
                              DisplayName = role.DisplayName,
                              Description = role.Description
                          })
            .ToListAsync(cancellation);

        return data;
    }

    public async Task<List<UserRoleDto>> GetAllUserRolesAsync(int userId, CancellationToken cancellation = default)
    {
        var context = readDbRepository.Context;
        var data = await (from role in context.Roles!
                          join userRole in context.UserRoles!.Where(i => i.UserId == userId) on role.Id equals userRole.RoleId into g
                          from ur in g.DefaultIfEmpty()
                          select new UserRoleDto
                          {
                              UserId = ur != null ? ur.UserId : userId,
                              Id = ur != null ? ur.Id : 0,
                              IsInRole = ur != null,
                              RoleId = role.Id,
                              Name = role.Name,
                              CreatedAt = role.CreatedAt,
                              UpdatedAt = role.UpdatedAt,
                              DisplayName = role.DisplayName,
                              Description = role.Description,
                          })
            .ToListAsync(cancellation);

        return data;
    }
}