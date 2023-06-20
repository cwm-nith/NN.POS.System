using System.Security.Claims;
using NN.POS.System.Core.Entities.Users;

namespace NN.POS.System.Core.IRepositories.Users;

public interface ITokenProvider
{
    string CreateToken(Claim[] claims);
    bool ValidateToken(string token);
}