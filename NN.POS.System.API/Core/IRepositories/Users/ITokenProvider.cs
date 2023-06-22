using System.Security.Claims;

namespace NN.POS.System.API.Core.IRepositories.Users;

public interface ITokenProvider
{
    string CreateToken(Claim[] claims);
    bool ValidateToken(string token);
}