using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using NN.POS.API.Core;
using NN.POS.API.Core.Entities.Users;
using NN.POS.API.Core.IRepositories.Roles;
using NN.POS.API.Core.IRepositories.Users;

namespace NN.POS.API.Infra.Repositories.Users;

public class TokenProvider(IUserRoleRepository userRoleRepository, AppSettings appSettings) : ITokenProvider
{
    public async Task<string> CreateTokenAsync(UserEntity user, CancellationToken cancellationToken = default)
    {

        var key = Encoding.UTF8.GetBytes(appSettings.Jwt.SigningKey);

        var expiryInMinutes = appSettings.Jwt.ExpiryInMinutes;

        List<Claim> claims =
        [
            new Claim("userId", user.Id.ToString()),
            new Claim("email", user.Email),
            new Claim(ClaimTypes.NameIdentifier, user.Name)
        ];

        var roles = await userRoleRepository.GetUserRolesAsync(user.Id, cancellationToken);
        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role.Name)));

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(expiryInMinutes),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            Issuer = appSettings.Jwt.Site,
            Audience = appSettings.Jwt.Site,

        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }

    public bool ValidateToken(string token)
    {
        throw new NotImplementedException();
    }
}