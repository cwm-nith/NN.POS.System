using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using NN.POS.System.API.Core;
using NN.POS.System.API.Core.IRepositories.Users;

namespace NN.POS.System.API.Infra.Repositories.Users;

public class TokenProvider : ITokenProvider
{
    private readonly IServiceProvider _serviceProvider;

    public TokenProvider(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public string CreateToken(Claim[] claims)
    {
        var option = _serviceProvider.GetService<AppSettings>() ?? new AppSettings();

        var key = Encoding.UTF8.GetBytes(option.Jwt.SigningKey);

        var expiryInMinutes = option.Jwt.ExpiryInMinutes;

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(expiryInMinutes),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            Issuer = option.Jwt.Site,
            Audience = option.Jwt.Site,

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