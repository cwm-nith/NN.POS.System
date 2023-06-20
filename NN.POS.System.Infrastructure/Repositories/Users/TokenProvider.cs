using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using NN.POS.System.Core.Entities.Users;
using NN.POS.System.Core.IRepositories.Users;
using NN.POS.System.Core;
using Microsoft.Extensions.DependencyInjection;

namespace NN.POS.System.Infrastructure.Repositories.Users;

public class TokenProvider : ITokenProvider
{
    private readonly IServiceProvider _serviceProvider;

    public TokenProvider(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public string CreateToken(Claim[] claims)
    {
        var option = _serviceProvider.GetService<JwtSetting>();

        var key = Encoding.UTF8.GetBytes(option!.SigningKey);

        var expiryInMinutes = option.ExpiryInMinutes;

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(expiryInMinutes),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            Issuer = option.Site,
            Audience = option.Site,

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