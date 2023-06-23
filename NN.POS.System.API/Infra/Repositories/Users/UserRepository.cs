using System.Linq.Expressions;
using System.Security.Claims;
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
    public UserRepository(IWriteDbRepository<UserTable> writeDbRepository, IReadDbRepository<UserTable> readDbRepository, ITokenProvider tokenProvider)
    {
        _writeDbRepository = writeDbRepository;
        _readDbRepository = readDbRepository;
        _tokenProvider = tokenProvider;
    }
    public async Task<UserEntity?> GetByIdAsync(int id)
    {
        var user = await _readDbRepository.FirstOrDefaultAsync(i => i.Id == id);
        return user?.ToEntity();
    }

    public async Task<UserEntity?> GetByUserNameAsync(string username)
    {
        var user = await _readDbRepository.FirstOrDefaultAsync(i => i.Username == username);
        return user?.ToEntity();
    }

    public async Task<UserEntity?> GetByUserEmailAsync(string email)
    {
        var user = await _readDbRepository.FirstOrDefaultAsync(i => i.Email == email);
        return user?.ToEntity();
    }

    public Task<PagedResult<UserEntity>> GetUsersAsync(Expression<Func<UserEntity, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public Task<bool> HasUserAsync()
    {
        return _readDbRepository.ExistsAsync(i => true);
    }

    public async Task<UserEntity> CreateUserAsync(UserEntity user)
    {
        var userTable = await _writeDbRepository.AddAsync(user.ToTable());
        var token = _tokenProvider.CreateToken(new Claim[]
        {
            new ("username", userTable.Username),
            new ("userId", userTable.Id.ToString()),
            new ("email", userTable.Email),
            new (ClaimTypes.NameIdentifier, userTable.Name),
        });
        var userEntity = userTable.ToEntity(token);
        return userEntity;
    }

    public Task<UserEntity> UpdateUserAsync(UserEntity user)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteUserAsync(int id)
    {
        throw new NotImplementedException();
    }
}