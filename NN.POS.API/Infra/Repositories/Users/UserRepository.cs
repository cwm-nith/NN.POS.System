using System.Linq.Expressions;
using NN.POS.API.Core.Entities.Users;
using NN.POS.API.Core.IRepositories.Users;
using NN.POS.API.Infra.Tables;
using NN.POS.API.Infra.Tables.User;
using NN.POS.Common.Pagination;

namespace NN.POS.API.Infra.Repositories.Users;

public class UserRepository(IWriteDbRepository<UserTable> writeDbRepository,
    IReadDbRepository<UserTable> readDbRepository, ITokenProvider tokenProvider) : IUserRepository
{
    public async Task<UserEntity?> GetByIdAsync(int id, CancellationToken cancellation = default)
    {
        var user = await readDbRepository.FirstOrDefaultAsync(i => i.Id == id, cancellation);
        return user?.ToEntity();
    }

    public async Task<UserEntity?> GetByUserNameAsync(string username, CancellationToken cancellation = default)
    {
        var user = await readDbRepository.FirstOrDefaultAsync(i => i.Username == username, cancellation);
        return user?.ToEntity();
    }

    public async Task<UserEntity?> GetByUserEmailAsync(string email, CancellationToken cancellation = default)
    {
        var user = await readDbRepository.FirstOrDefaultAsync(i => i.Email == email, cancellation);
        return user?.ToEntity();
    }

    public async Task<PagedResult<UserEntity>> GetUsersAsync(Expression<Func<UserTable, bool>> predicate, IPagedQuery q, CancellationToken cancellation = default)
    {
        var data = await readDbRepository.BrowseAsync(predicate, q, cancellation);
        return data.Map(i => i.ToEntity());
    }

    public async Task<bool> HasUserAsync(CancellationToken cancellation = default)
    {
        return await readDbRepository.ExistsAsync(i => true, cancellation);
    }

    public async Task<bool> IsUserExistedAsync(int id, CancellationToken cancellation = default)
    {
        return await readDbRepository.ExistsAsync(i => i.Id == id, cancellation);
    }

    public async Task<UserEntity> CreateUserAsync(UserEntity user, CancellationToken cancellation = default)
    {
        var userTable = await writeDbRepository.AddAsync(user.ToTable(), cancellation);
        var token = await tokenProvider.CreateTokenAsync(user, cancellation);
        var userEntity = userTable.ToEntity(token);
        return userEntity;
    }

    public async Task<UserEntity> UpdateUserAsync(UserEntity user, CancellationToken cancellation = default)
    {
        await writeDbRepository.UpdateAsync(user.ToTable(), cancellation);
        return user;
    }

    public async Task<bool> DeleteUserAsync(int id, CancellationToken cancellation = default)
    {
        var num = await writeDbRepository.DeleteAsync(id, cancellation);
        return num > 0; 
    }
}