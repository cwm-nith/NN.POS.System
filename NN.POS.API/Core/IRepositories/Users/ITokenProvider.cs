using NN.POS.API.Core.Entities.Users;

namespace NN.POS.API.Core.IRepositories.Users;

public interface ITokenProvider
{
    Task<string> CreateTokenAsync(UserEntity user, CancellationToken cancellationToken = default);
    bool ValidateToken(string token);
}