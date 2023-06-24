using System.Linq.Expressions;
using NN.POS.System.API.Commons.Pagination;
using NN.POS.System.API.Core.Entities.Users;
using NN.POS.System.API.Core.IRepositories.Users;
using NN.POS.System.API.Infra.Tables;
using NN.POS.System.API.Infra.Tables.User;

namespace NN.POS.System.API.Infra.Repositories.Users;

public class UserRepository : IUserRepository
{
    private readonly IWriteDbRepository<UserTable> _writeDbRepository;
    private readonly IReadDbRepository<UserTable> _readDbRepository;
    private readonly ITokenProvider _tokenProvider;
    public UserRepository(IWriteDbRepository<UserTable> writeDbRepository,
        IReadDbRepository<UserTable> readDbRepository, ITokenProvider tokenProvider)
    {
        _writeDbRepository = writeDbRepository;
        _readDbRepository = readDbRepository;
        _tokenProvider = tokenProvider;
    }
    public async Task<UserEntity?> GetByIdAsync(int id, CancellationToken cancellation = default)
    {
        var user = await _readDbRepository.FirstOrDefaultAsync(i => i.Id == id, cancellation);
        return user?.ToEntity();
    }

    public async Task<UserEntity?> GetByUserNameAsync(string username, CancellationToken cancellation = default)
    {
        var user = await _readDbRepository.FirstOrDefaultAsync(i => i.Username == username, cancellation);
        return user?.ToEntity();
    }

    public async Task<UserEntity?> GetByUserEmailAsync(string email, CancellationToken cancellation = default)
    {
        var user = await _readDbRepository.FirstOrDefaultAsync(i => i.Email == email, cancellation);
        return user?.ToEntity();
    }

    public async Task<PagedResult<UserEntity>> GetUsersAsync(Expression<Func<UserTable, bool>> predicate, IPagedQuery q, CancellationToken cancellation = default)
    {
        var data = await _readDbRepository.BrowseAsync(predicate, q, cancellation);
        return data.Map(i => i.ToEntity());
    }

    public Task<bool> HasUserAsync(CancellationToken cancellation = default)
    {
        return _readDbRepository.ExistsAsync(i => true, cancellation);
    }

    public Task<bool> IsUserExistedAsync(int id, CancellationToken cancellation = default)
    {
        return _readDbRepository.ExistsAsync(i => i.Id == id, cancellation);
    }

    public async Task<UserEntity> CreateUserAsync(UserEntity user, CancellationToken cancellation = default)
    {
        var userTable = await _writeDbRepository.AddAsync(user.ToTable(), cancellation);
        var token = await _tokenProvider.CreateTokenAsync(user, cancellation);
        var userEntity = userTable.ToEntity(token);
        return userEntity;
    }

    public async Task<UserEntity> UpdateUserAsync(UserEntity user, CancellationToken cancellation = default)
    {
        await _writeDbRepository.UpdateAsync(user.ToTable(), cancellation);
        return user;
    }

    public async Task<bool> DeleteUserAsync(int id, CancellationToken cancellation = default)
    {
        var num = await _writeDbRepository.DeleteAsync(id, cancellation);
        return num > 0; 
    }
}