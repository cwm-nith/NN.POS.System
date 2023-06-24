using System.Linq.Expressions;
using NN.POS.System.API.Commons.Pagination;
using NN.POS.System.API.Core.Entities.Users;
using NN.POS.System.API.Infra.Tables.User;

namespace NN.POS.System.API.Core.IRepositories.Users;

public interface IUserRepository
{
    Task<UserEntity?> GetByIdAsync(int id, CancellationToken cancellation = default);
    Task<UserEntity?> GetByUserNameAsync(string username, CancellationToken cancellation = default);
    Task<UserEntity?> GetByUserEmailAsync(string email, CancellationToken cancellation = default);
    Task<PagedResult<UserEntity>> GetUsersAsync(Expression<Func<UserTable, bool>> predicate, PagedQuery q, CancellationToken cancellation = default);
    Task<bool> HasUserAsync(CancellationToken cancellation = default);
    Task<bool> IsUserExistedAsync(int id, CancellationToken cancellation = default);

    Task<UserEntity> CreateUserAsync(UserEntity user, CancellationToken cancellation = default);
    Task<UserEntity> UpdateUserAsync(UserEntity user, CancellationToken cancellation = default);
    Task<bool> DeleteUserAsync(int id, CancellationToken cancellation = default);


}