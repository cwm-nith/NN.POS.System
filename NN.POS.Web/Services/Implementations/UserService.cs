using System.Security.Claims;
using NN.POS.Web.Models;
using NN.POS.Web.Services.Interfaces;

namespace NN.POS.Web.Services.Implementations;

public class UserService : IUserService
{
    public AuthenticateUser GetUser(List<Claim> claims)
    {
        var username = claims.Where(c => c.Type == "nameid")
            .Select(x => x.Value).FirstOrDefault();

        var userId = claims.Where(c => c.Type == "userId")
            .Select(x => x.Value).FirstOrDefault();
        
        var email = claims.Where(c => c.Type == "email")
            .Select(x => x.Value).FirstOrDefault();

        var roles = claims.Where(c => c.Type == "role")
            .Select(x => x.Value).ToList();

        var nbf = claims.Where(c => c.Type == "nbf")
            .Select(x => x.Value).FirstOrDefault();

        var exp = claims.Where(c => c.Type == "exp")
            .Select(x => x.Value).FirstOrDefault();

        var iat = claims.Where(c => c.Type == "iat")
            .Select(x => x.Value).FirstOrDefault();

        var iss = claims.Where(c => c.Type == "iss")
            .Select(x => x.Value).FirstOrDefault();

        var aud = claims.Where(c => c.Type == "aud")
            .Select(x => x.Value).FirstOrDefault();


        return new AuthenticateUser
        {
            Aud = aud,
            Email = email,
            Exp = int.Parse(exp ?? "0"),
            Iat = int.Parse(iat ?? "0"),
            Iss = iss,
            UserName = username,
            Nbf = int.Parse(nbf ?? "0"),
            Roles = roles,
            UserId = int.Parse(userId ?? "0")
        };
    }
}