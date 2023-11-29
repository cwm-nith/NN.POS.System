using NN.POS.Model.Dtos.Roles;

namespace NN.POS.API.Core.IRepositories.Roles;

public interface IUserRoleRepository
{
    Task<bool> AddRoleToUserAsync(int userId, int roleId, CancellationToken cancellation = default);
    Task<bool> UserRoleExistedAsync(int userId, int roleId, CancellationToken cancellation = default);
    Task<bool> RemoveUserRoleAsync(int userId, int roleId, CancellationToken cancellation = default);
    Task<List<UserRoleDto>> GetUserRolesAsync(int userId, CancellationToken cancellation = default);
    Task<List<UserRoleDto>> GetAllUserRolesAsync(int userId, CancellationToken cancellation = default);
}