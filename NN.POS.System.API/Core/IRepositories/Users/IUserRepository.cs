using System.Linq.Expressions;
using NN.POS.System.API.Commons.Pagination;
using NN.POS.System.API.Core.Entities.Users;

namespace NN.POS.System.API.Core.IRepositories.Users;

public interface IUserRepository
{
    Task<UserEntity?> GetByIdAsync(int id);
    Task<UserEntity?> GetByUserNameAsync(string username);
    Task<UserEntity?> GetByUserEmailAsync(string email);
    Task<PagedResult<UserEntity>> GetUsersAsync(Expression<Func<UserEntity, bool>> predicate);
    Task<bool> HasUserAsync();

    Task<UserEntity> CreateUserAsync(UserEntity user);
    Task<UserEntity> UpdateUserAsync(UserEntity user);
    Task<bool> DeleteUserAsync(int id);


}