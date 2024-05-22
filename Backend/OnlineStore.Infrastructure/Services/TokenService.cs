using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OnlineStore.Application.Options;
using OnlineStore.Application.Params;

namespace OnlineStore.Infrastructure.Services;
public sealed class TokenService : ITokenService
{
    private readonly JwtTokenOption _option;

    public TokenService(IOptionsSnapshot<JwtTokenOption> jwtOption)
    {
        _option = jwtOption.Value;
    }

    public string GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);

    }

    public string GenerateToken(TokenParam tokenParam)
    {
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_option.Key));
        var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
        var tokeOptions = new JwtSecurityToken(
            issuer: _option.Issuer,
            audience: _option.Issuer,
            claims: new List<Claim>
            {
              new(ClaimTypes.Role, tokenParam.Permission),
              new(Variable.Session, tokenParam.SessionId.ToString()),
              new(Variable.UserName, tokenParam.UserName)
            },
            expires: DateTime.Now.AddMinutes(5),
            signingCredentials: signinCredentials
        );
        var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
        return tokenString;
    }
}