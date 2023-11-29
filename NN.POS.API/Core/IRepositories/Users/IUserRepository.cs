using System.Linq.Expressions;
using NN.POS.API.Core.Entities.Users;
using NN.POS.API.Infra.Tables.User;
using NN.POS.Common.Pagination;

namespace NN.POS.API.Core.IRepositories.Users;

public interface IUserRepository
{
    Task<UserEntity?> GetByIdAsync(int id, CancellationToken cancellation = default);
    Task<UserEntity?> GetByUserNameAsync(string username, CancellationToken cancellation = default);
    Task<UserEntity?> GetByUserEmailAsync(string email, CancellationToken cancellation = default);
    Task<PagedResult<UserEntity>> GetUsersAsync(Expression<Func<UserTable, bool>> predicate, IPagedQuery q, CancellationToken cancellation = default);
    Task<bool> HasUserAsync(CancellationToken cancellation = default);
    Task<bool> IsUserExistedAsync(int id, CancellationToken cancellation = default);

    Task<UserEntity> CreateUserAsync(UserEntity user, CancellationToken cancellation = default);
    Task<UserEntity> UpdateUserAsync(UserEntity user, CancellationToken cancellation = default);
    Task<bool> DeleteUserAsync(int id, CancellationToken cancellation = default);


}