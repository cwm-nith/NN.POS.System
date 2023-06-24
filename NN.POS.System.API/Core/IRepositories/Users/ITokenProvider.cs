using System.Security.Claims;
using NN.POS.System.API.Core.Entities.Users;

namespace NN.POS.System.API.Core.IRepositories.Users;

public interface ITokenProvider
{
    Task<string> CreateTokenAsync(UserEntity user, CancellationToken cancellationToken = default);
    bool ValidateToken(string token);
}