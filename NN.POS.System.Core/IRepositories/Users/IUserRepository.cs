using NN.POS.System.Common.Pagination;
using NN.POS.System.Core.Entities.Users;
using System.Linq.Expressions;

namespace NN.POS.System.Core.IRepositories.Users;

public interface IUserRepository
{
    Task<UserEntity?> GetByIdAsync(Guid id);
    Task<UserEntity> GetByUserNameAsync(string username);
    Task<UserEntity> GetByUserEmailAsync(string email);
    Task<PagedResult<UserEntity>> GetUsersAsync(Expression<Func<UserEntity, bool>> predicate);

    Task<UserEntity> CreateUserAsync(UserEntity user);
    Task<UserEntity> UpdateUserAsync(UserEntity user);
    Task<bool> DeleteUserAsync(Guid id);


}