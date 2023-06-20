using System.Linq.Expressions;
using System.Security.Claims;
using NN.POS.System.Common.Pagination;
using NN.POS.System.Core.Entities.Users;
using NN.POS.System.Core.IRepositories.Users;
using NN.POS.System.Infrastructure.Tables;
using NN.POS.System.Infrastructure.Tables.User;

namespace NN.POS.System.Infrastructure.Repositories.Users;

public class UserRepository : IUserRepository
{
    private readonly IWriteDbRepository<UserTable> _writeDbRepository;
    private readonly IReadDbRepository<UserTable> _readDbRepository;
    private readonly ITokenProvider _tokenProvider;
    public UserRepository(IWriteDbRepository<UserTable> writeDbRepository, IReadDbRepository<UserTable> readDbRepository, ITokenProvider tokenProvider)
    {
        _writeDbRepository = writeDbRepository;
        _readDbRepository = readDbRepository;
        _tokenProvider = tokenProvider;
    }
    public async Task<UserEntity?> GetByIdAsync(Guid id)
    {
        var user = await _readDbRepository.FirstOrDefaultAsync(i => i.Id == id);
        return user?.ToEntity();
    }

    public Task<UserEntity> GetByUserNameAsync(string username)
    {
        throw new NotImplementedException();
    }

    public Task<UserEntity> GetByUserEmailAsync(string email)
    {
        throw new NotImplementedException();
    }

    public Task<PagedResult<UserEntity>> GetUsersAsync(Expression<Func<UserEntity, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public async Task<UserEntity> CreateUserAsync(UserEntity user)
    {
        var userTable = await _writeDbRepository.AddAsync(user.ToTable());
        var token = _tokenProvider.CreateToken(new Claim[]
        {
            new ("username", userTable.Username),
            new ("userId", userTable.Id.ToString()),
        });
        var userEntity = userTable.ToEntity(token);
        return userEntity;
    }

    public Task<UserEntity> UpdateUserAsync(UserEntity user)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteUserAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}