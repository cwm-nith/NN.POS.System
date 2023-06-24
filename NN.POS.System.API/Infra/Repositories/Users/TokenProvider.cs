using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using NN.POS.System.API.Core;
using NN.POS.System.API.Core.Entities.Users;
using NN.POS.System.API.Core.IRepositories.Roles;
using NN.POS.System.API.Core.IRepositories.Users;

namespace NN.POS.System.API.Infra.Repositories.Users;

public class TokenProvider : ITokenProvider
{
    private readonly IUserRoleRepository _userRoleRepository;
    private readonly AppSettings _appSettings;

    public TokenProvider(IUserRoleRepository userRoleRepository, AppSettings appSettings)
    {
        _userRoleRepository = userRoleRepository;
        _appSettings = appSettings;
    }

    public async Task<string> CreateTokenAsync(UserEntity user, CancellationToken cancellationToken = default)
    {

        var key = Encoding.UTF8.GetBytes(_appSettings.Jwt.SigningKey);

        var expiryInMinutes = _appSettings.Jwt.ExpiryInMinutes;

        List<Claim> claims = new()
        {
            new Claim("userId", user.Id.ToString()),
            new Claim("email", user.Email),
            new Claim(ClaimTypes.NameIdentifier, user.Name),
        };

        var roles = await _userRoleRepository.GetUserRolesAsync(user.Id, cancellationToken);
        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role.Name)));

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(expiryInMinutes),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            Issuer = _appSettings.Jwt.Site,
            Audience = _appSettings.Jwt.Site,

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